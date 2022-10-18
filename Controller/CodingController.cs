namespace Coding_Tracker.Controller
{
    internal class CodingController
    {
        internal static List<CodingSession> table = new List<CodingSession>();

        internal static void MenuControl()
        {
            bool systemRunning = true;
            DatabaseAccess.CreateTable();
            Visualization.TableVisualisationEngine.Welcome();

            do
            {
                switch (UserInput.MenuItemSelected())
                {
                    case "v":
                        ViewControl();
                        break;
                    case "i":
                        InsertControl();
                        break;
                    case "e":
                        UpdateControl();
                        break;
                    case "d":
                        DeleteControl();
                        break;
                    case "q":
                        systemRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input.Press enter to redo.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            } while (systemRunning);
            
        }

        internal static void InsertControl()
        {
            List<string> timeList = CalculateDuration("Please input the start time in this format", "Please input the end time in this format");
            DatabaseAccess.InsertTable(timeList[2], timeList[0], timeList[1]);
            DatabaseAccess.ViewTable();
            Console.WriteLine("Row Inputed. Please hit enter to go to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void DeleteControl()
        {
            Console.Clear();
            DatabaseAccess.ViewTable();
            var id = UserInput.GetItemById("Enter ID number of Row you want to Delete.");
            DatabaseAccess.DeleteTable(id);
            Console.Clear();
            DatabaseAccess.ViewTable();
            Console.WriteLine("Row Deleted. Please hit enter to go to main menu");
            Console.ReadLine();
            Console.Clear();            
        }

        internal static void UpdateControl()
        {
            Console.Clear();
            DatabaseAccess.ViewTable();
            var id = UserInput.GetItemById("Enter ID number of row you want to update.");
            List<string> timeList = CalculateDuration("Please input the start time in this format to update", "Please input the end time in this format to update ");
            DatabaseAccess.UpdateTable(id, timeList[0], timeList[1], timeList[2]);
            Console.Clear();
            DatabaseAccess.ViewTable();
            Console.WriteLine("Row Updated.  Please hit enter to go to main menu.");
            Console.ReadLine();
            Console.Clear();
        }
        internal static void ViewControl()
        {
            Console.Clear();
            DatabaseAccess.ViewTable();
            Console.WriteLine("Press enter to return to main menu.");
            Console.Read();
            Console.Clear();
        }

        internal static List<string> CalculateDuration(string startTimeMessage, string endTimeMessage)
        {
            List<string> timeList = new List<string>();
            string format = "M/dd/yyyy h:mm tt";
            bool isNegative;
            DateTime startTime, endTime;
            TimeSpan ts;
            do
            {
                startTime = UserInput.GetTime($"{startTimeMessage} {format} (ex: 10/17/2022 7:00 pm).", format);
                Console.Clear();
                endTime = UserInput.GetTime($"{endTimeMessage} {format} (ex: 10/17/2022 7:00 pm).", format);
                Console.Clear();
                ts = endTime - startTime;
                isNegative = Validation.CheckForNegativeHours(ts);
            } while (!isNegative);
            timeList.Add(startTime.ToString());
            timeList.Add(endTime.ToString());
            timeList.Add(ts.ToString("c"));
            return timeList;

        }

    }

}
