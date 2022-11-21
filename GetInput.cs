using PhoneBookApp.Controllers;
using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp
{
    public class GetInput
    {
        public void MainMenu()
        {
            PhoneBookAppController phoneBook = new();

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
                    DisplayTable displayTable = new();
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

        public Tuple<string, string> GetNewContactInput()
        {
            PhoneBookAppController phoneBookAppController= new();

            Console.WriteLine("New Contact");

            Console.WriteLine("\nContact Name or 0 to return to Menu:");
            string contactName = Console.ReadLine();

            if (contactName == "0") { phoneBookAppController.CreateContact(); }

            while (!Validation.IsNameValid(contactName))
            {
                Console.WriteLine("\nPlease input a valid Contact Name:");
                contactName = Console.ReadLine();
            }

            Console.WriteLine("\nPhone Number or 0 to return to Menu:");
            string contactNumber = Console.ReadLine();

            if (contactNumber == "0") { phoneBookAppController.CreateContact(); }

            while (!Validation.IsPhoneNumberValid(contactNumber))
            {
                Console.WriteLine("\nPlease input a valid Contact Number:");
                contactNumber = Console.ReadLine();
            }

            return Tuple.Create(contactName, contactNumber);
        }

        public Contact GetDeleteContactInput()
        {
            var context = new PhoneBookAppDbContext();

            Console.WriteLine("Delete Contact");

            Console.WriteLine("\nId of contact to Delete or 0 to go back to Menu:");
            string contactId = Console.ReadLine();

            if (contactId == "0") { MainMenu(); }

            while (!Validation.IsIdValid(contactId))
            {
                Console.WriteLine("\nInvalid entry, please enter the Id of contact to Delete or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0") { MainMenu(); }
            }

            int id = Int32.Parse(contactId);
            var deleteContact = context.Contacts.Find(id);

            while (deleteContact == null)
            {
                Console.WriteLine("\nInvalid entry, please enter a valid Id or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0") { MainMenu(); }

                id = Int32.Parse(contactId);
                deleteContact = context.Contacts.Find(id);
            }

            return deleteContact;
        }

        public Contact GetEditContactInput()
        {
            DisplayTable displayTable = new();
            PhoneBookAppController phoneBookAppController = new();

            bool nameUpdated = true;
            bool numberUpdated = true;

            var context = new PhoneBookAppDbContext();

            Console.WriteLine("\nId of contact to Edit or 0 to go back to Menu:");
            string contactId = Console.ReadLine();

            if (contactId == "0") { MainMenu(); }

            while (!Validation.IsIdValid(contactId))
            {
                Console.WriteLine("\nInvalid entry, please enter the Id of contact to Delete or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0") { MainMenu(); }
            }

            int id = Int32.Parse(contactId);
            var editContact = context.Contacts.Find(id);

            while (editContact == null)
            {
                Console.WriteLine("\nInvalid entry, please enter a valid Id or 0 to go back to Menu:");
                contactId = Console.ReadLine();

                if (contactId == "0") { MainMenu(); }

                id = Int32.Parse(contactId);
                editContact = context.Contacts.Find(id);
            }

            displayTable.DisplayContact(id);

            Console.WriteLine("\nEnter update to Contact Name or 0 to return to Menu (Press Enter to use current Name):");
            string contactName = Console.ReadLine();

            if (contactName == "0") { phoneBookAppController.EditContact(); }

            else if (contactName == "")
            {
                contactName = editContact.Name.ToString();
                nameUpdated = false;
            }

            while (!Validation.IsNameValid(contactName))
            {
                Console.WriteLine("\nPlease input a valid Contact Name:");
                contactName = Console.ReadLine();

                if (contactName == "0") { phoneBookAppController.EditContact(); }

                else if (contactName == "")
                {
                    contactName = editContact.Name.ToString();
                    nameUpdated = false;
                }
            }

            Console.WriteLine("\nEnter update to Phone Number or 0 to return to Menu (Press Enter to use current Phone Number):");
            string contactNumber = Console.ReadLine();

            if (contactNumber == "0") { phoneBookAppController.EditContact(); }

            else if (contactNumber == "")
            {
                contactNumber = editContact.PhoneNumber.ToString();
                numberUpdated = false;
            }

            while (!Validation.IsPhoneNumberValid(contactNumber))
            {
                Console.WriteLine("\nPlease input a valid Contact Number:");
                contactNumber = Console.ReadLine();

                if (contactNumber == "0") { phoneBookAppController.EditContact(); }

                else if (contactNumber == "")
                {
                    contactNumber = editContact.PhoneNumber.ToString();
                    numberUpdated = false;
                }
            }

            if (nameUpdated == false && numberUpdated == false)
            {
                Console.WriteLine("\nContact unchanged.\nPress Enter...");
                Console.ReadLine();

                MainMenu();
            }

            editContact.Name = contactName;
            editContact.PhoneNumber = contactNumber;

            return editContact;
        }

        public string GetSearchContactInput()
        {
            Console.WriteLine("Search Contact");

            Console.WriteLine("\nEnter Name or Number to search for or 0 to go back to Menu:");
            string contactSearch = Console.ReadLine();

            if (contactSearch == "0") { getInputMainMenu(); }
        }

    }
}
