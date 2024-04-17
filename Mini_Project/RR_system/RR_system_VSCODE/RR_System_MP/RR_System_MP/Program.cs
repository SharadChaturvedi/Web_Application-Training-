
using RR_System_MP.RR_system;
//using RR_System_MP.RR_system.User
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RR_System_MP
{

    
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("         **********  !!!!!_______Hello! Welcome to Railway Registration_______!!!!!  ************     ");

           
                {
                    Console.WriteLine("\n DROP DOWN YOUR CREDENTIALS :");
                    Console.WriteLine("1. Admin====>");
                    Console.WriteLine("2. User=====>");
                    Console.WriteLine("3. Exit=====>");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Admin.Adminsection();
                            break;
                        case "2":
                            User.CheckUserAndProceed();
                            User.checking(); // Call the checking method to proceed with user options
                            break;
                        case "3":
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }



