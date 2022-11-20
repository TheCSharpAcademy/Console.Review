using ConsoleTableExt;
using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp;

internal class DisplayTable
{
    internal static void ShowContacts<T>(List<T> tableData) where T : class
    {
        ConsoleTableBuilder
            .From(tableData)
            .WithTitle("Contacts")
            .ExportAndWriteLine();
    }

    public void DisplayContacts()
    {
        Console.Clear();

        var context = new PhoneBookAppDbContext();

        List<Contact> contacts = new List<Contact>();

        foreach (var contact in context.Contacts)
        {
            contacts.Add(contact);                
        }

        ShowContacts(contacts);
    }

    public void DisplayContact(int id)
    {
        Console.Clear();
        Console.WriteLine("Edit Contact\n");
        var context = new PhoneBookAppDbContext();

        List<Contact> contacts = new List<Contact>();

        foreach (var contact in context.Contacts)
        {
            if (contact.Id == id)
            {
                contacts.Add(contact);
            }     
        }      

        ShowContacts(contacts);
    }
}    
