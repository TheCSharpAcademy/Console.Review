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

    internal void Add(List<ContactClass> list)
    {
        foreach (ContactClass entity in list)
        {
            TableData.Add(
                new List<object>
                {
                    entity.Id,
                    entity.Name,
                    entity.PhoneNumber
                }
                );
        }
    }

    internal void Clear()
    {
        TableData.Clear();
    }
}