
internal class Database
{
    internal Database()
    {
        using (var db = new PhoneBookContext())
        {
            try
            {
                db.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }
    }

    internal void Add(ContactClass Contact)
    {
        using (var db = new PhoneBookContext())
        {
            try
            {
                db.Contacts.Add(Contact);
                db.SaveChanges();

                Console.WriteLine("\nOperation was successful!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nERROR: Operation was unsuccessful!");
            }
        }
    }

    internal void Delete(int Id)
    {
        using (var db = new PhoneBookContext())
        {
            var Contact = new ContactClass { Id = Id };

            try
            {
                db.Contacts.Remove(Contact);
                db.SaveChanges();

                Console.WriteLine("\nOperation was successful!");
            } 
            catch (Exception)
            {
                Console.WriteLine("This record doesn't exist!");
            }
        }
    }

    internal void Update(ContactClass Contact)
    {
        using (var db = new PhoneBookContext())
        {
            var record = db.Contacts.Find(Contact.Id);

            if (record != null)
            {
                record.Name = Contact.Name;
                record.PhoneNumber = Contact.PhoneNumber;

                db.Contacts.Update(record);
                db.SaveChanges();

                Console.WriteLine("\nOperation was successful!");
            } 
            else
            {
                Console.WriteLine("This record doesn't exist!");
            }
        }
    }

    internal ContactClass Read(int Id)
    {
        ContactClass? Record;

        using (var db = new PhoneBookContext())
        {
            
            Record = db.Contacts
                .Where(Record => Record.Id == Id)
                .Select(Record => new ContactClass { Id = Record.Id, Name = Record.Name, PhoneNumber = Record.PhoneNumber })
                .FirstOrDefault();
            
            if (Record == null) Console.WriteLine("This record doesn't exist!");
        }

        return Record!;
    }

    internal List<ContactClass> ReadAll()
    {
        List<ContactClass> Records;

        using (var db = new PhoneBookContext())
        {
            Records = db.Contacts
                .Select(Record => new ContactClass { Id = Record.Id, Name = Record.Name, PhoneNumber = Record.PhoneNumber })
                .ToList();
        }

        return Records;
    }
}

