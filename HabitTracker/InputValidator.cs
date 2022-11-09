using HabitTracker;

internal static class InputValidator
{

    public static string GetEntryDate()
    {
        Console.Write("What date are you adding for? (yyyy-mm-dd): ");
        string input = Console.ReadLine();
        while (!DateTime.TryParse(input, out DateTime date))
        {
            Console.Write("This is not a valid date, please use the format 'yyyy-mm-dd'");
            input = Console.ReadLine();
        }
        return input;
    }

    public static int GetEntryQuantity(string measurement)
    {
        Console.Write($"How many {measurement} did you do? ");
        string input = Console.ReadLine();
        while (!Int32.TryParse(input, out int parsed))
        {
            Console.Write("This is not a valid quantity, please enter a number: ");
            input = Console.ReadLine();
        }
        return Int32.Parse(input);
    }

    public static int GetHabitId()
    {
        string input = string.Empty;
        DAL dal = new DAL();

        try
        {
            string listOfHabits = string.Empty;
            List<Habit> validHabits = dal.GetHabits();
            foreach (Habit habit in validHabits)
            {
                listOfHabits += $"{habit}\n";
            }
            Console.WriteLine(listOfHabits);
            List<int> validHabitIds = validHabits.Select(h => h.id).ToList();
            Console.Write("Enter the number corresponding to the habit this entry is for: ");
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int result))
                {
                    if (validHabitIds.Contains(result))
                    {
                        return result;
                    }
                }
                Console.Write("This is not a valid id, please enter a number: ");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


        return Int32.Parse(input);
    }

    public static string GetHabitMeasurement()
    {
        Console.Write("What is the measurement of your habit? ");
        string input = Console.ReadLine();
        while (input.Length == 0)
        {
            Console.Write("Habit measurement should not be empty. Try again: ");
            input = Console.ReadLine();
        }
        return input;
    }

    public static string GetHabitName()
    {
        Console.Write("What is the name of your habit? ");
        string input = Console.ReadLine();
        while (input.Length == 0)
        {
            Console.Write("Habit name should not be empty. Try a new name: ");
            input = Console.ReadLine();
        }
        return input;
    }

    public static int GetIdForRemoval()
    {
        Console.Write("Which entry do you want to remove? ");
        DAL dal = new DAL();

        List<int> validIds = dal.GetEntries().Select(o => o.id).ToList();
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out int result))
            {
                if (validIds.Contains(result))
                {
                    return result;
                }
            }
            Console.Write("This is not a valid id, please enter a number: ");
        }

    }

    public static int GetIdForUpdate()
    {
        Console.Write("Which entry do you want to update? ");
        DAL dal = new DAL();
        List<int> validIds = dal.GetEntries().Select(o => o.id).ToList();
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out int result))
            {
                if (validIds.Contains(result))
                {
                    return result;
                }
            }
            Console.Write("This is not a valid id, please enter a number: ");
        }

    }

    public static bool IsValidOption(string? input)
    {
        string[] validOptions = { "v", "h", "a", "d", "u", "c", "0" };
        foreach (string validOption in validOptions)
        {
            if (input == validOption)
            {
                return true;
            }
        }
        return false;
    }

    public static string GetUserOption()
    {
        string input = Console.ReadLine();
        while (!IsValidOption(input))
        {
            Console.Write("This is not a valid input. Please enter one of the above options: ");
            input = Console.ReadLine();
        }
        return input;
    }
}