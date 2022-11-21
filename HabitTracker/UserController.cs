using HabitTracker;

internal static class UserController
{
    public static void AddEntry()
    {
        int habitId = UserInput.GetHabitId();
        string date = UserInput.GetEntryDate();
        int quantity = UserInput.GetEntryQuantity(DataAccessor.GetHabit(habitId).Measurement);
        DataAccessor.AddEntry(date, quantity, habitId);
        Console.WriteLine("\nSuccessfully added new entry.");
    }

    public static void CreateHabit()
    {
        string name = UserInput.GetHabitName();
        string measurement = UserInput.GetHabitMeasurement();
        DataAccessor.CreateHabit(name, measurement);
        Console.WriteLine("\nSuccessfully added new habit.");
    }

    public static void DeleteEntry()
    {
        Viewer.DisplayEntryTable();
        int id = UserInput.GetIdForRemoval();
        DataAccessor.DeleteEntry(id);
        Console.WriteLine("\nSuccessfully deleted entry.");
    }

    public static void ExitApp()
    {
        Environment.Exit(0);
    }

    public static void InitializeDatabase()
    {
        DataAccessor.CreateMainTableIfMissing();
    }

    public static void UpdateEntry()
    {
        Viewer.DisplayEntryTable();
        int id = UserInput.GetIdForUpdate();
        int habitId = UserInput.GetHabitId();
        int quantity = UserInput.GetEntryQuantity(DataAccessor.GetHabit(habitId).Measurement);
        string date = UserInput.GetEntryDate();
        DataAccessor.UpdateEntry(id, quantity, date);
        Console.WriteLine("\nSuccessfully updated entry.");
    }

    public static void ViewHighest()
    {
        int habitId = UserInput.GetHabitId();
        Entry entry = DataAccessor.GetHighestEntryForHabit(habitId);
        Viewer.DisplayHighestEntry(entry);
    }
}