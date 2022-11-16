using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Controllers
{
    public class PhoneBookAppController
    {
        public void CreateContact()
        {
            GetInput getInput = new GetInput();

            var context = new PhoneBookAppDbContext();

            var newContact = new Contact();

            bool isNameValid = false;

            Console.WriteLine("New Contact");

            Console.WriteLine("\nCentact Name:");
            string contactName = Console.ReadLine();            

            while (!Validation.IsNameValid(contactName))
            {
                Console.WriteLine("\nPlease input a valid Centact Name:");
                contactName = Console.ReadLine();
            }

            Console.WriteLine("\nPhone Number:");
            string contactNumber = Console.ReadLine();

            while (!Validation.IsPhoneNumberValid(contactNumber))
            {
                Console.WriteLine("\nPlease input a valid Centact Number:");
                contactNumber = Console.ReadLine();
            }

            newContact.Name = contactName;
            newContact.PhoneNumber = contactNumber;            

            context.Contacts.Add(newContact);
            context.SaveChanges();

            Console.WriteLine("\nContact Created.\nPress Enter...");
            Console.ReadLine();

            getInput.MainMenu();
        }

        public void DeleteContact()
        {
            GetInput getInput = new GetInput();
            DisplayTable displayTable = new DisplayTable();

            displayTable.DisplayContacts();

            var context = new PhoneBookAppDbContext();            

            Console.WriteLine("Delete Contact");

            Console.WriteLine("\nId of contact to Delete or 0 to go back to Menu:");
            string contactId = Console.ReadLine();

            if (contactId == "0")
            {
                getInput.MainMenu();
            }

            while (!Validation.IsIdValid(contactId))
            {
                Console.WriteLine("\nInvalid entry, please enter the Id of contact to Delete or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0")
                {
                    getInput.MainMenu();
                }
            }

            int id = Int32.Parse(contactId);
            var deleteContact = context.Contacts.Find(id);

            while (deleteContact == null)
            {
                Console.WriteLine("\nInvalid entry, please enter a valid Id or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0")
                {
                    getInput.MainMenu();
                }

                id = Int32.Parse(contactId);
                deleteContact = context.Contacts.Find(id);
            }            

            context.Contacts.Remove(deleteContact);
            context.SaveChanges();

            Console.WriteLine("\nContact Deleted.\nPress Enter...");
            Console.ReadLine();

            getInput.MainMenu();
        }

        public void EditContact()
        {
            GetInput getInput = new GetInput();
            DisplayTable displayTable = new DisplayTable();

            displayTable.DisplayContacts();

            var context = new PhoneBookAppDbContext();

            Console.WriteLine("Edit Contact");

            Console.WriteLine("\nId of contact to Edit or 0 to go back to Menu:");
            string contactId = Console.ReadLine();

            if (contactId == "0")
            {
                getInput.MainMenu();
            }

            while (!Validation.IsIdValid(contactId))
            {
                Console.WriteLine("\nInvalid entry, please enter the Id of contact to Delete or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0")
                {
                    getInput.MainMenu();
                }
            }

            int id = Int32.Parse(contactId);
            var editContact = context.Contacts.Find(id);

            while (editContact == null)
            {
                Console.WriteLine("\nInvalid entry, please enter a valid Id or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0")
                {
                    getInput.MainMenu();
                }

                id = Int32.Parse(contactId);
                editContact = context.Contacts.Find(id);
            }

            Console.WriteLine("\nCentact Name:");
            string contactName = Console.ReadLine();
            Console.WriteLine("\nPhone Number:");
            string contactNumber = Console.ReadLine();

            editContact.Name = contactName;
            editContact.PhoneNumber = contactNumber;

            context.Contacts.Update(editContact);
            context.SaveChanges();

            Console.WriteLine("\nContact Updated.\nPress Enter...");
            Console.ReadLine();

            getInput.MainMenu();
        }

        public void SearchContact()
        {
            GetInput getInput = new GetInput();
            //DisplayTable displayTable = new DisplayTable();

            //displayTable.DisplayContacts();

            var context = new PhoneBookAppDbContext();

            Console.WriteLine("Search Contact");

            Console.WriteLine("\nEnter Name or Number to search for or 0 to go back to Menu:");
            string contactSearch = Console.ReadLine();

            if (contactSearch == "0")
            {
                getInput.MainMenu();
            }

            var searchContact = context.Contacts.Where(j => j.Name.Contains(contactSearch)).ToList();
            var searchNumber = context.Contacts.Where(j => j.PhoneNumber.Contains(contactSearch)).ToList();
            searchContact.AddRange(searchNumber);

            FormatTable.ShowContacts(searchContact);

            if (searchContact.Count == 1)
            {
                Console.WriteLine($"\n{searchContact.Count} Contact Found.\nPress Enter...");
                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine($"\n{searchContact.Count} Contacts Found.\nPress Enter...");
                Console.ReadLine();
            }
            

            getInput.MainMenu();
        }
    }
}
