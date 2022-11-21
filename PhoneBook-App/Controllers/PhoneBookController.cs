
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

    internal void Navigate(int Option)
    {
        switch (Option)
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
        string Name = UserInput.GetString("Name");
        string PhoneNumber = UserInput.GetPhoneNumber();

        Database.Add(new ContactClass { 
            Name = Name, 
            PhoneNumber = PhoneNumber 
        });
    }

    private void DeleteContact()
    {
        ShowContacts();

        int Id = UserInput.GetInt("ID");

        Database.Delete(Id);
    }

    private void UpdateContact()
    {
        ShowContacts();

        int Id = UserInput.GetInt("ID");

        var Contact = Database.Read(Id);

        if (Contact != null)
        {
            Console.WriteLine("What do you want to update?  1. Name     2. Phone Number");
            string option = UserInput.GetUpdateOptionString();

            switch(option)
            {
                case "1":
                    Contact.Name = UserInput.GetString("Name");
                    break;
                case "2":
                    Contact.PhoneNumber = UserInput.GetPhoneNumber();
                    break;
            }
        }
        Database.Update(Contact);
    }
}

