using Coding_Tracker.Controller;
using ConsoleTableExt;

namespace Coding_Tracker.Visualization
{
    internal class TableVisualisationEngine
    {
        internal static void CreateVisualTable()
        {
            ConsoleTableBuilder
                .From(CodingController.table)
                .ExportAndWriteLine();
        }
        internal static void Welcome()
        {
            Console.WriteLine(@"Welcome to your Coding Tracker where you will input a start time 
and end time to calculate and store your duration of coding.");
        }
        internal static void MenuOptions()
        {
            Console.WriteLine(@"Here are your Menu Options:
__________________________
V - View Records
I - Insert New Record
E - Edit Record
D - Delete Record
Q - Quit Program
__________________________");
        }
    }
}
