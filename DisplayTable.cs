using PhoneBookApp.Controllers;
using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    internal class DisplayTable
    {
        public void DisplayContacts()
        {
            var context = new PhoneBookAppDbContext();

            List<Contact> contacts = new List<Contact>();

            foreach (var contact in context.Contacts)
            {
                contacts.Add(contact);                
            }

            FormatTable.ShowContacts(contacts);
        }        
    }
}
