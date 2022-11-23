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

    internal void Add(ContactClass contact)
    {
        using (var db = new PhoneBookContext())
        {
            try
            {
                db.Contacts.Add(contact);
                db.SaveChanges();

                Console.WriteLine("\nOperation was successful!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nERROR: Operation was unsuccessful!");
            }
        }
    }

    internal void Delete(int id)
    {
        using (var db = new PhoneBookContext())
        {
            var contact = new ContactClass { Id = id };

            try
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();

                Console.WriteLine("\nOperation was successful!");
            } 
            catch (Exception)
            {
                Console.WriteLine("This record doesn't exist!");
            }
        }
    }

    internal void Update(ContactClass contact)
    {
        using (var db = new PhoneBookContext())
        {
            var record = db.Contacts.Find(contact.Id);

            if (record != null)
            {
                record.Name = contact.Name;
                record.PhoneNumber = contact.PhoneNumber;

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

    internal ContactClass Read(int id)
    {
        ContactClass? record;

        using (var db = new PhoneBookContext())
        {
            
            record = db.Contacts
                .Where(record => record.Id == id)
                .Select(record => new ContactClass { Id = record.Id, Name = record.Name, PhoneNumber = record.PhoneNumber })
                .FirstOrDefault();
            
            if (record == null) Console.WriteLine("This record doesn't exist!");
        }

        return record!;
    }

    internal List<ContactClass> ReadAll()
    {
        List<ContactClass> records;

        using (var db = new PhoneBookContext())
        {
            records = db.Contacts
                .Select(record => new ContactClass { Id = record.Id, Name = record.Name, PhoneNumber = record.PhoneNumber })
                .ToList();
        }

        return records;
    }
}

