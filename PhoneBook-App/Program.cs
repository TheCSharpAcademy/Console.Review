PhoneBookController Program = new();

while (true)
{
    Program.ShowMenu();

    Program.Navigate(UserInput.GetInt("Option"));

    Console.WriteLine("\nPress ENTER to Continue...");
    Console.ReadLine();
}