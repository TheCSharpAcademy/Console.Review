
internal class PhoneBookController
{
    readonly Database Database = new();
    readonly TableVisualisationEngine TVEngine = new();
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
        TVEngine.Add(Database.ReadAll());
        Console.Clear();
        TVEngine.Print();
        TVEngine.Clear();
    }

    private void AddContact()
    {
        string Name = UserInput.GetString("Name");
        string PhoneNumber = UserInput.GetString("Phone Number");

        Database.Add(new ContactClass { Name = Name, PhoneNumber = PhoneNumber });
    }

    private void DeleteContact()
    {
        int Id = UserInput.GetInt("ID");

        Database.Delete(Id);
    }

    private void UpdateContact()
    {
        int Id = UserInput.GetInt("ID");
        string Name = UserInput.GetString("Name");
        string PhoneNumber = UserInput.GetString("Phone Number");

        Database.Update(new ContactClass { Id = Id, Name = Name, PhoneNumber = PhoneNumber });
    }


}

