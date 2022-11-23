internal class PhoneBookController
{
    readonly Database Database = new();
    readonly TableVisualisationEngine TableVisualisationEngine = new();
    internal void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Show contacts");
        Console.WriteLine("2. Add contact");
        Console.WriteLine("3. Delete contact");
        Console.WriteLine("4. Update contact");
        Console.WriteLine("5. Exit");
    }

    internal void Navigate(int option)
    {
        switch (option)
        {
            case 1:
                ShowContacts();
                break;
            case 2:
                AddContact();
                break;
            case 3:
                DeleteContact();
                break;
            case 4:
                UpdateContact();    
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Wrong Option!");
                break;
        }
    }

    private void ShowContacts()
    {
        Console.Clear();
        TableVisualisationEngine.Add(Database.ReadAll());
        TableVisualisationEngine.Print();
        TableVisualisationEngine.Clear();
    }

    private void AddContact()
    {
        string name = UserInput.GetString("Name");
        string phoneNumber = UserInput.GetPhoneNumber();

        Database.Add(new ContactClass { 
            Name = name, 
            PhoneNumber = phoneNumber 
        });
    }

    private void DeleteContact()
    {
        ShowContacts();

        int id = UserInput.GetInt("ID");

        Database.Delete(id);
    }

    private void UpdateContact()
    {
        ShowContacts();

        int id = UserInput.GetInt("ID");

        var contact = Database.Read(id);

        if (contact != null)
        {
            Console.WriteLine("What do you want to update?  1. Name     2. Phone Number");
            string option = UserInput.GetUpdateOptionString();

            switch(option)
            {
                case "1":
                    contact.Name = UserInput.GetString("Name");
                    break;
                case "2":
                    contact.PhoneNumber = UserInput.GetPhoneNumber();
                    break;
            }
        }
        Database.Update(contact);
    }
}

