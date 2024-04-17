using System;
using System.Linq;

namespace RR_System_MP.RR_system
{
    public class Admin
    {
        static RR_systemEntities db = new RR_systemEntities();




        public static void Adminsection()
        {
           


            while (true)
            {
                if (!IsAdminRegistered())
                {
                    Console.WriteLine("Invalid admin credentials.");
                    Console.WriteLine("Type 'Enter' to try again or Type 'exit' to go back.");
                    string x = Console.ReadLine();
                    if (x.ToLower() == "exit")
                        return;
                    continue;
                }

                Console.Clear();
                Console.WriteLine("-----------------               WELCOME TO ADMIN SECTION            ---------------------");

                Console.WriteLine("Choose your option & proceed-->");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Soft Delete Train");
                Console.WriteLine("3. Reactivate Train");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTrain();
                        break;
                    case "2":
                        SoftDeleteTrain();
                        break;
                    case "3":
                        ReactivateTrain();
                        break;
                  
                    case "4":
                        Console.WriteLine("Exiting admin options.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static bool IsAdminRegistered()
        {
            // Ask for admin credentials
            Console.WriteLine("Enter Admin Username: ");
            string adminUsername = Console.ReadLine();
            Console.WriteLine("Enter Admin Password: ");
            string adminPassword = ReadPassword();

            // Check if admin credentials exist in the database
            var admin = db.Admindetails.FirstOrDefault(a => a.Admin_name== adminUsername && a.Admin_password == adminPassword);

            // Return true if admin exists, otherwise false
            return admin != null;
        }







        public static void AddTrain()
        {
            Console.WriteLine("..........Add New Train..........");

            Console.Write("Enter Train ID: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();

            Console.Write("Enter Departure City: ");
            string departureCity = Console.ReadLine();

            Console.Write("Enter Arrival City: ");
            string arrivalCity = Console.ReadLine();

            Console.Write("Enter Status of Train (Active/Inactive): ");
            bool status = Console.ReadLine().ToLower() == "active";

            Console.WriteLine("................             *Train added successfully*           ...............");

            // Add train to database
            var newTrain = new Traindetail
            {
                Train_id = trainID,
                Train_name = trainName,
                City_of_Departure = departureCity,
                city_of_Arrival = arrivalCity,
                Status_of_Train = status
            };


            db.Traindetails.Add(newTrain);
            db.SaveChanges();
            Console.WriteLine("Enter first ac seat: ");
            int @firstAcSeats=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second ac seat: ");
            int@SecAcSeats=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter sleeper seats");
            int @SLSeats = int.Parse(Console.ReadLine());
            db.AddclassSeats(trainID, @firstAcSeats, @SecAcSeats, @SLSeats);
            Console.WriteLine("................         *Seats Added Sucessfylly*           ............");



            Console.WriteLine("Enter first ac price: ");
            int @firstAcSeatsfare = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second ac price: ");
            int @SecAcSeatsfare = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter sleeper price: ");
            int @SLSeatsfare = int.Parse(Console.ReadLine());
            db.AddclassFair(trainID, @firstAcSeatsfare, @SecAcSeatsfare, @SLSeatsfare);
            Console.WriteLine("................        *Price Added Sucessfully*               .........");
               

        }

        





        public static void SoftDeleteTrain()
        {
            Console.WriteLine("..........Soft Delete Train..........");

            Console.Write("Enter Train ID to delete: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            var train = db.Traindetails.FirstOrDefault(t => t.Train_id == trainID);

            if (train != null)
            {
                train.Status_of_Train = false;
                db.SaveChanges();
                Console.WriteLine("........... Train status changed to Not in Use   ......... ");
            }
            else
            {
                Console.WriteLine(" ERROR 404.......Train not found.......");
            }
        }





        public static void ReactivateTrain()
        {
            Console.WriteLine("..........Reactivate Train..........");

            Console.Write("Enter Train ID to reactivate: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            var train = db.Traindetails.FirstOrDefault(t => t.Train_id == trainID);

            if (train != null)
            {
                train.Status_of_Train = true;
                db.SaveChanges();
                Console.WriteLine("..........Train status changed to Running Back successfully.............");
            }
            else
            {
                Console.WriteLine("Train not found.");
            }
        }
        public static string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Ignore any key that's not a backspace or Enter
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    // Append the character to the password
                    pass += key.KeyChar;
                    Console.Write("*"); // Print '*' instead of the actual character
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    // If backspace is pressed, remove the last character from the password
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b"); // Erase the character from the console
                }
            }
            while (key.Key != ConsoleKey.Enter);

            return pass;
        }
    }
}
