using HabitTracker;
using Microsoft.Data.Sqlite;

class Program
{
    private static DAL dal = new DAL();
    static void Main(string[] args)
    {
        DisplayTitle();

        InitializeDatabase();

        while (true)
        {
            DisplayOptionsMenu();
            string userInput = InputValidator.GetUserOption();
            ProcessInput(userInput);
        }
    }

    private static void ProcessInput(string userInput)
    {
        switch (userInput)
        {
            case "v":
                ViewTable();
                break;
            case "h":
                ViewHighest();
                break;
            case "a":
                AddEntry();
                break;
            case "d":
                DeleteEntry();
                break;
            case "u":
                UpdateEntry();
                break;
            case "c":
                CreateHabit();
                break;
            case "0":
                ExitApp();
                break;
            default:
                break;
        }
    }

    private static void ViewTable()
    {
        List<Entry> entries = dal.GetEntries();
        string output = string.Empty;
        foreach (Entry entry in entries)
        {
            output += $"{entry}\n";
        }
        Console.WriteLine(output);

    }

    private static void ViewHighest()
    {
        int habitId = InputValidator.GetHabitId();
        Entry entry = dal.GetHighestEntryForHabit(habitId);
        Console.WriteLine($"Below is the most {entry.measurement} you have done in one go:");
        Console.WriteLine(entry);
    }

    private static void AddEntry()
    {
        int habitId = InputValidator.GetHabitId();
        string date = InputValidator.GetEntryDate();
        int quantity = InputValidator.GetEntryQuantity(dal.GetHabit(habitId).measurement);
        dal.AddEntry(date, quantity, habitId);
        Console.WriteLine("\nSuccessfully added new entry.");

    }

    private static void DeleteEntry()
    {
        ViewTable();
        int id = InputValidator.GetIdForRemoval();
        dal.DeleteEntry(id);
    }

    private static void UpdateEntry()
    {
        ViewTable();
        int id = InputValidator.GetIdForUpdate();
        int habitId = InputValidator.GetHabitId();
        int quantity = InputValidator.GetEntryQuantity(dal.GetHabit(habitId).measurement);
        dal.UpdateEntry(id, quantity);
    }

    private static void CreateHabit()
    {
        string name = InputValidator.GetHabitName();
        string measurement = InputValidator.GetHabitMeasurement();
        dal.CreateHabit(name, measurement);
        Console.WriteLine("Successfully added new habit.");
    }

    private static void ExitApp()
    {
        Environment.Exit(0);
    }

    private static void DisplayOptionsMenu()
    {
        Console.WriteLine("\nChoose an action from the following list:");
        Console.WriteLine("\tv - View your tracker");
        Console.WriteLine("\th - View your biggest entry for a habit");
        Console.WriteLine("\ta - Add a new entry");
        Console.WriteLine("\td - Delete an entry");
        Console.WriteLine("\tu - Update an entry");
        Console.WriteLine("\tc - Create new habit");
        Console.WriteLine("\t0 - Quit this application");
        Console.Write("Your option? ");
    }

    private static void InitializeDatabase()
    {
        dal.CreateMainTableIfMissing();
    }

    private static void DisplayTitle()
    {
        Console.WriteLine("Habit Tracker\r");
        Console.WriteLine("-------------\n");
    }
}