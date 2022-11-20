using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp.Controllers;

public class PhoneBookAppController
{
    public void CreateContact()
    {
        GetInput getInput = new GetInput();

        var context = new PhoneBookAppDbContext();

        var newContact = new Contact();

        Console.WriteLine("New Contact");

        Console.WriteLine("\nContact Name or 0 to return to Menu:");
        string contactName = Console.ReadLine();       
        
        if (contactName == "0") { CreateContact(); }

        while (!Validation.IsNameValid(contactName))
        {
            Console.WriteLine("\nPlease input a valid Contact Name:");
            contactName = Console.ReadLine();
        }

        Console.WriteLine("\nPhone Number or 0 to return to Menu:");
        string contactNumber = Console.ReadLine();

        if (contactNumber == "0") { CreateContact(); }

        while (!Validation.IsPhoneNumberValid(contactNumber))
        {
            Console.WriteLine("\nPlease input a valid Contact Number:");
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

        if (contactId == "0") { getInput.MainMenu(); }

        while (!Validation.IsIdValid(contactId))
        {
            Console.WriteLine("\nInvalid entry, please enter the Id of contact to Delete or 0 to go back to Menu:");
            contactId = Console.ReadLine();

            if (contactId == "0") { getInput.MainMenu(); }
        }

        int id = Int32.Parse(contactId);
        var deleteContact = context.Contacts.Find(id);

        while (deleteContact == null)
        {
            Console.WriteLine("\nInvalid entry, please enter a valid Id or 0 to go back to Menu:");
            contactId = Console.ReadLine();

            if (contactId == "0") { getInput.MainMenu(); }

            id = Int32.Parse(contactId);
            deleteContact = context.Contacts.Find(id);
        }

        Console.WriteLine($"Are you sure you want to delete the entry for {deleteContact.Name}? \n\nType \"yes\" to Delete or any other Entry to Cancel");

        string confirmDelete = Console.ReadLine();

        if (confirmDelete.ToLower() == "yes") 
        {
            context.Contacts.Remove(deleteContact);
            context.SaveChanges();

            Console.WriteLine("\nContact Deleted.\nPress Enter...");
            Console.ReadLine();

            getInput.MainMenu();
        }

        else
        {
            getInput.MainMenu();
        }    
    }

    public void EditContact()
    {
        bool nameUpdtaed = true;
        bool numberUpdtated = true;

        GetInput getInput = new GetInput();
        DisplayTable displayTable = new DisplayTable();

        displayTable.DisplayContacts();

        var context = new PhoneBookAppDbContext();        

        Console.WriteLine("\nId of contact to Edit or 0 to go back to Menu:");
        string contactId = Console.ReadLine();

        if (contactId == "0") { getInput.MainMenu(); }

        while (!Validation.IsIdValid(contactId))
        {
            Console.WriteLine("\nInvalid entry, please enter the Id of contact to Delete or 0 to go back to Menu:");
            contactId = Console.ReadLine();

            if (contactId == "0") { getInput.MainMenu(); }
        }

        int id = Int32.Parse(contactId);
        var editContact = context.Contacts.Find(id);

        while (editContact == null)
        {
            Console.WriteLine("\nInvalid entry, please enter a valid Id or 0 to go back to Menu:");
            contactId = Console.ReadLine();

            if (contactId == "0") { getInput.MainMenu(); }

            id = Int32.Parse(contactId);
            editContact = context.Contacts.Find(id);            
        }

        displayTable.DisplayContact(id);

        Console.WriteLine("\nEnter update to Contact Name or 0 to return to Menu (Press Enter to use current Name):");
        string contactName = Console.ReadLine();

        if (contactName == "0") { EditContact(); }

        else if (contactName == "")
        {
            contactName = editContact.Name.ToString();
            nameUpdtaed = false;
        }

        while (!Validation.IsNameValid(contactName))
        {
            Console.WriteLine("\nPlease input a valid Contact Name:");
            contactName = Console.ReadLine();

            if (contactName == "0") { EditContact(); }

            else if (contactName == "")
            {
                contactName = editContact.Name.ToString();
                nameUpdtaed = false;
            }
        }

        Console.WriteLine("\nEnter update to Phone Number or 0 to return to Menu (Press Enter to use current Phone Number):");
        string contactNumber = Console.ReadLine();

        if (contactNumber == "0") { EditContact(); }

        else if (contactNumber == "")
        {
            contactNumber = editContact.PhoneNumber.ToString();
            numberUpdtated= false;
        }

        while (!Validation.IsPhoneNumberValid(contactNumber))
        {
            Console.WriteLine("\nPlease input a valid Contact Number:");
            contactNumber = Console.ReadLine();

            if (contactNumber == "0") { EditContact(); }

            else if (contactNumber == "")
            {
                contactNumber = editContact.PhoneNumber.ToString();
                numberUpdtated= false;
            }
        }
                
        if (nameUpdtaed == false && numberUpdtated == false)
        {
            Console.WriteLine("\nContact unchanged.\nPress Enter...");
            Console.ReadLine();

            getInput.MainMenu();
        }

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

        var context = new PhoneBookAppDbContext();

        Console.WriteLine("Search Contact");

        Console.WriteLine("\nEnter Name or Number to search for or 0 to go back to Menu:");
        string contactSearch = Console.ReadLine();

        if (contactSearch == "0") { getInput.MainMenu(); }

        var searchContact = context.Contacts.Where(j => j.Name.Contains(contactSearch)).ToList();
        var searchNumber = context.Contacts.Where(j => j.PhoneNumber.Contains(contactSearch)).ToList();
        searchContact.AddRange(searchNumber);

        Console.Clear();
        DisplayTable.ShowContacts(searchContact);

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
