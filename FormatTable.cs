using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    internal class FormatTable
    {
        internal static void ShowContacts<T>(List<T> tableData) where T : class
        {
            ConsoleTableBuilder
                .From(tableData)
                .WithTitle("Contacts")
                .ExportAndWriteLine();
        }
    }
}
