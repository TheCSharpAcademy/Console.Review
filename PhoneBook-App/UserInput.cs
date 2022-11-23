using System.Text.RegularExpressions;

static class UserInput
{
    static internal int GetInt(string title)
    {
        int value = 0;

        while(value == 0)
        {
            Console.WriteLine($"\nInput [{title}]: ");
            string? input = Console.ReadLine();

            Int32.TryParse(input, out value);

            if (value == 0) Console.WriteLine("Wrong format!");
        }

        return value;
    }

    static internal string GetPhoneNumber()
    {
        string pattern = "^[+]370[0-9]{8}";

        string? input = "";

        while (input.Length != 12 || !Regex.IsMatch(input, pattern))
        {
            Console.WriteLine($"Input Phone Number [+370********]: ");
            input = Console.ReadLine();

            if (!Regex.IsMatch(input, pattern) || input.Length != 12) 
                Console.WriteLine("Wrong format!");
        }

        return input;
    }

    static internal string GetString(string title)
    {
        string? input = "";

        while (input == "")
        {
            Console.WriteLine($"Input [{title}]: ");
            input = Console.ReadLine();
        }

        return input;
    }

    static internal string GetUpdateOptionString()
    {
        string[] options = { "1", "2" };

        string? input = "";

        while (!Array.Exists(options, element => element == input))
        {
            Console.WriteLine($"Input [Option]: ");
            input = Console.ReadLine();
        }

        return input;
    }
}

