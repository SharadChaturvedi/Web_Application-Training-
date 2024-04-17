using System;
using System.Linq;
using System.Xml;

namespace RR_System_MP.RR_system
{
    public class User
    {
        static RR_systemEntities db = new RR_systemEntities();
        static Class_price cp = new Class_price();






        public static void CheckUserAndProceed()
        {
            Console.Clear();
            Console.WriteLine("..........          Welcome To User Registration            ...........");

            Console.Write("-->Enter User ID: ");
            string userID = Console.ReadLine();

            // Check if user exists
            var existingUser = db.Userdetails.FirstOrDefault(u => u.userID == userID);

            if (existingUser != null)
            {
                Console.WriteLine(".....User already exists. Proceed for further process.....");
                checking(); // Call checking method directly if user exists
            }
            else
            {
                Console.WriteLine(".....User does not exist. Proceed for user Registration.....");
                RegisterUser();
                Console.WriteLine("User registered successfully. Proceed with------>");
                Ticket_Booking();
            }
        }








        public static void RegisterUser()
        {
            Console.WriteLine("-->Enter UserID");
            string userID = Console.ReadLine();

            Console.Write("-->Enter Password: ");
            string userPassword = Console.ReadLine();

            Console.Write("-->Enter Email: ");
            string userEmail = Console.ReadLine();

            var newUser = new Userdetail
            {
                userID = userID,
                userPassword = userPassword,
                userEmail = userEmail
            };

            db.Userdetails.Add(newUser);
            db.SaveChanges();

            Console.WriteLine("User registered successfully.");
        }







        public static void Ticket_Booking()
        {
            for (int i = 0; i < 5; i++) // Allow booking up to 5 tickets
            {
                // Fetch train details from the database
                var trainDetails = db.Traindetails.ToList();

                // Display train details in tabular format
                Console.WriteLine("Train Details:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("| Train ID | Train Name            | Departure City | Arrival City  | Status |");
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (var train in trainDetails)
                {
                    Console.WriteLine($"| {train.Train_id,-9} | {train.Train_name,-20} | {train.City_of_Departure,-14} | {train.city_of_Arrival,-13} | {(train.Status_of_Train ? "Active" : "Inactive"),-6} |");
                }
                Console.WriteLine("--------------------------------------------------------------------------------");

                // Prompt the user to enter the train ID for ticket booking
                Console.Write("Enter Train_Id(No.) for Ticket Booking: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the User ID: ");
                string U_ID = Console.ReadLine();

                Random Rn = new Random();
                Console.Write("Enter Class(1AC/2AC/SL): ");
                String CS = Console.ReadLine();
                Console.WriteLine($"Captcha=>{Rn.Next(10, 200)}");
                Console.Write("Enter the Given Captcha to Confirm The Ticket: ");
                int Rnd = Convert.ToInt32(Console.ReadLine());

                int T_id = Rnd + 69;

                var Booked = db.Traindetails.FirstOrDefault(Bid => Bid.Train_id == Id);
                var U_validate = db.Userdetails.FirstOrDefault(Ud => Ud.userID == U_ID);

                if (Booked != null && U_validate != null)
                {
                    if (Booked.Status_of_Train == true)
                    {
                        Ticket_Booking TB = new Ticket_Booking();
                        Console.Write("Enter Your Name: ");
                        string Name = Convert.ToString(Console.ReadLine() + "\n");

                        Console.Write("Enter Gender: ");
                        string Gn = Console.ReadLine() + "\n";

                        TB.Ticket_no = T_id;
                        TB.Train_id = Id;
                        TB.userID = U_ID;
                        TB.Class = CS;

                        db.Ticket_Booking.Add(TB);
                        db.SaveChanges();
                        Console.WriteLine(" YOUR TICKET HAS BEEN BOOKED SUCESSFULLY..............\n\n");

                        db.SeatAvl(Id, CS);

                        Random r = new Random();
                        var x = db.Class_price.FirstOrDefault(t => t.Train_no == Id);

                        Console.WriteLine("\t\t\t\t*Ticket Detail*\n\n");
                        Console.WriteLine($"Name:-->{Name}");
                        Console.WriteLine($"tGender:-->{Gn}");
                        Console.WriteLine($"Train_Id:-->{Id}\n");
                        Console.WriteLine($"Ticketno:-->{T_id}\n");
                        var clas = db.Seat_available.Where(t => t.Train_Id == Id);

                        if (x.Train_no == Id)
                        {
                            if (CS == "1AC")
                            {
                                Console.WriteLine($"TotalPrice:--> {x.C1AC}\n");
                            }
                            else if (CS == "2AC")
                            {
                                Console.WriteLine($"TotalPrice:--> {x.C2AC} \n");
                            }
                            else if (CS == "SL")
                            {
                                Console.WriteLine($"TotalPrice:--> {x.SL} \n");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Details\n");
                            }
                        }

                        Console.WriteLine($"PNR No:--> {r.Next(10000, 90000)} \n");
                    }
                    else
                    {
                        Console.WriteLine("/n=>This train is not Active......Sorry Booking failed.");
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\t\t\t\t INVALID DETAILS ........");
                }

                // Ask if the user wants to book more tickets
                Console.WriteLine("Do you want to book more tickets? (Yes/No)");
                string response = Console.ReadLine().Trim().ToLower();
                if (response != "yes")
                    break; // Exit the loop if the user does not want to book more tickets
            }
        }

        public static void CheckBookingStatus(string userID)
        {
            // Retrieve all booked tickets for the given user
            var bookedTickets = db.Ticket_Booking.Where(t => t.userID == userID).ToList();

            if (bookedTickets.Any())
            {
                Console.WriteLine("List of Booked Tickets:");
                foreach (var ticket in bookedTickets)
                {
                    Console.WriteLine($"Ticket Number: {ticket.Ticket_no}");
                    Console.WriteLine($"Train ID: {ticket.Train_id}");
                    Console.WriteLine($"Class: {ticket.Class}");
                    // You can display more ticket details here if needed
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No tickets booked for this user.");
            }
        }






        public static void checking()
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Cancel Ticket");
                Console.WriteLine("3. Check Booking Status");
                Console.WriteLine("4.Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Ticket_Booking();
                        break;
                    case "2":
                        Ticket_cancellation();
                        break;
                    case "3":
                        Console.Write("Enter User ID to check booking status: ");
                        string userID = Console.ReadLine();
                        CheckBookingStatus(userID);
                        break;
                    case "4":
                        Console.WriteLine("Exiting booking options.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }






        public static void Ticket_cancellation()
        {
            Ticket_Cancellation Tc = new Ticket_Cancellation();
            Ticket_Booking tb = new Ticket_Booking();

            Console.WriteLine("Enter the Booking Id for Cancellation");
            Console.WriteLine("\t\t\t\t\t\t*Cancel Your Ticket*\n\n");
            Console.Write("Enter Train Id: ");
            int Id1 = Convert.ToInt32(Console.ReadLine() + "\n");
            Console.Write("Enter your Ticket_no: ");
            int Tn_1 = Convert.ToInt32(Console.ReadLine() + "\n");
            Random Rn = new Random();
            int a = Rn.Next(10000, 90000);
            int amt = 0;
            string cls = db.Ticket_Booking.Where(t => t.Ticket_no == Tn_1).Select(t => t.Class).FirstOrDefault().ToString();
            if (cls.ToUpper() == "1AC")
            {
                amt = (int)db.Class_price.Where(t => t.Train_no == Id1).Select(t => t.C1AC).FirstOrDefault();
            }
            else if (cls.ToUpper() == "2AC")
            {
                amt = (int)db.Class_price.Where(t => t.Train_no == Id1).Select(t => t.C2AC).FirstOrDefault();
            }
            else if (cls.ToUpper() == "SL")
            {
                amt = (int)db.Class_price.Where(t => t.Train_no == Id1).Select(t => t.SL).FirstOrDefault();
            }



            int refundAmt = (int)(amt * 0.7); // 30% less than the original price
            db.CancelTicket(a, Tn_1, Id1, refundAmt);
           
            Console.WriteLine("\nTicket cancellation Sucessful...............");
            Console.WriteLine($"Refund Amount: {refundAmt}");
            

            db.Seatcancelled(Id1, cls);
            

        }
    }

}
