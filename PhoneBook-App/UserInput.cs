
static class UserInput
{
    static internal int GetInt(string Title)
    {
        int x = 0;

        while(x == 0)
        {
            Console.WriteLine($"\nInput [{Title}]: ");
            string? Input = Console.ReadLine();

            Int32.TryParse(Input, out x);

            if (x == 0) Console.WriteLine("Wrong format!");
        }

        return x;
    }

    static internal string GetString(string Title)
    {
        string? Input = "";

        while (Input == "")
        {
            Console.WriteLine($"Input [{Title}]: ");
            Input = Console.ReadLine();
        }

        return Input;
    }
}

