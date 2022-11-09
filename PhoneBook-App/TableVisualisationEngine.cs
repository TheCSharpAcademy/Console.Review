using ConsoleTableExt;

internal class TableVisualisationEngine
{
    private readonly List<List<object>> TableData = new();

    internal void Print()
    {
        ConsoleTableBuilder
            .From(TableData)
            .WithTitle("PhoneBook-App", ConsoleColor.Blue, ConsoleColor.Black)
            .WithColumn("ID", "Name", "Phone Number")
            .ExportAndWriteLine();
    }

    internal void Add(List<ContactClass> List)
    {
        foreach (ContactClass Entity in List)
        {
            TableData.Add(
                new List<object>
                {
                    Entity.Id,
                    Entity.Name,
                    Entity.PhoneNumber
                }
                );
        }
    }

    internal void Clear()
    {
        TableData.Clear();
    }
}