using PhoneBookApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class GetInput
    {
        public void MainMenu()
        {
            PhoneBookAppController phoneBook = new PhoneBookAppController();

            Console.Clear();
            Console.WriteLine("Welcome to the Phone Book App!\n");
            
            Console.WriteLine("1 - Enter new Contact");
            Console.WriteLine("2 - Edit Contact");
            Console.WriteLine("3 - Delete Contact");
            Console.WriteLine("4 - Search Contacts");
            Console.WriteLine("5 - Display Contacts");
            Console.WriteLine("0 - Exit");

            Console.WriteLine("\nEnter Selection:");
            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {              
                case "0":
                    Console.WriteLine("\nGoodBye!");
                    Environment.Exit(0);
                    break;
                case "1":                    
                    phoneBook.CreateContact();
                    break;
                case "2":
                    phoneBook.EditContact();
                    break;
                case "3":                    
                    phoneBook.DeleteContact();
                    break;
                case "4":
                    phoneBook.SearchContact();
                    break;
                case "5":
                    DisplayTable displayTable = new DisplayTable();
                    displayTable.DisplayContacts();
                    Console.WriteLine("\nPress Enter...");
                    Console.ReadLine();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid selection, please enter a number from 0-5.\nPress Enter...");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
        }

    }
}
