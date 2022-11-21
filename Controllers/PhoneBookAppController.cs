using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp.Controllers;

public class PhoneBookAppController
{
    public void CreateContact()
    {
        GetInput getInput = new();

        var context = new PhoneBookAppDbContext();

        var newContact = new Contact();

        var (contactName, contactNumber) = getInput.GetNewContactInput(); // TODO : No tuple

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
        GetInput getInput = new();
        DisplayTable displayTable = new();

        displayTable.DisplayContacts();

        var context = new PhoneBookAppDbContext();

        var deleteContact = getInput.GetDeleteContactInput();                    

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
        GetInput getInput = new();
        DisplayTable displayTable = new();

        displayTable.DisplayContacts();

        var context = new PhoneBookAppDbContext();        

        Contact editContact = getInput.GetEditContactInput();

        context.Contacts.Update(editContact);
        context.SaveChanges();

        Console.WriteLine("\nContact Updated.\nPress Enter...");
        Console.ReadLine();

        getInput.MainMenu();
    }

    public void SearchContact()
    {
        GetInput getInput = new();            

        var context = new PhoneBookAppDbContext();
        
        string contactSearch = getInput.GetSearchContactInput();        

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
