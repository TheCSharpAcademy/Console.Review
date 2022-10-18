using System.Globalization;

namespace Coding_Tracker
{
    internal class UserInput
    {
        private static DateTime time;

        internal static string MenuItemSelected()
        {
            Visualization.TableVisualisationEngine.MenuOptions();
            return Console.ReadLine().Trim().ToLower(); 
        }

        internal static DateTime GetTime(string message, string format)
        {
            bool timeIsExtracted = false;
            CultureInfo provider = CultureInfo.InvariantCulture;
            do
            {
                Console.WriteLine(message);
                var timeString = Console.ReadLine();

                try
                {
                    time = DateTime.ParseExact(timeString, format, provider);
                    Console.WriteLine($"{timeString} converts to {time}.");
                    timeIsExtracted = true;
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{timeString} is not in the correct format.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }while (!timeIsExtracted);
            return time;


        }

        internal static int GetItemById(string message)
        {
            bool idCheck = true;
            int id;
            do
            {
                Console.WriteLine(message);
                id = Validation.IsANumberEntered(message);
                idCheck = Validation.CheckIfIdIsThere(id);
            } while (!idCheck);
            return id;
        }
    }
}
