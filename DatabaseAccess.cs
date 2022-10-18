using Coding_Tracker.Visualization;
using System.Configuration;
using System.Data.SQLite;


namespace Coding_Tracker
{
    internal class DatabaseAccess
    {
        internal static string dbConnectionString = ConfigurationManager.ConnectionStrings["CodingTrackerDB"].ConnectionString;
        internal static void CreateTable()
        {
            using (var connection = new SQLiteConnection(dbConnectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS codingTracker (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    StartTime TEXT,
                    EndTime TEXT,
                    Duration TEXT
                    )";

                    tableCmd.ExecuteNonQuery();
                }
            }
        }

        internal static void UpdateTable(int id, string startTime, string endTime, string duration)
        {
            using (var connection = new SQLiteConnection(dbConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE codingTracker SET StartTime = @startTime, EndTime = @endTime, Duration = @duration WHERE Id = @id";
                    command.Parameters.AddWithValue("@startTime", startTime);
                    command.Parameters.AddWithValue("@endTime", endTime);
                    command.Parameters.AddWithValue("@duration",duration);
                    command.Parameters.AddWithValue("@id", id);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void InsertTable(string duration, string startTime, string endTime)
        {
            using (var connection = new SQLiteConnection(dbConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO codingTracker (StartTime, EndTime, Duration) VALUES(@startTime, @endTime, @duration)";
                    command.Parameters.AddWithValue("@startTime", startTime);
                    command.Parameters.AddWithValue("@endTime", endTime);
                    command.Parameters.AddWithValue("@duration", duration);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void DeleteTable(int id)
        {
            using (var connection = new SQLiteConnection(dbConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM codingTracker WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void ViewTable()
        {
            Controller.CodingController.table.Clear();
            using (var connection = new SQLiteConnection(dbConnectionString))
            {
                connection.Open();
                var commandString = "SELECT * FROM codingTracker";
                using (var command = new SQLiteCommand(commandString,connection))
                {
                    using SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Controller.CodingController.table.Add(new Controller.CodingSession
                        {
                            Id = reader.GetInt32(0),
                            StartTime = reader.GetString(1),
                            EndTime = reader.GetString(2),
                            Duration = reader.GetString(3)
                        });
                    }
                }
                
                                                                             
            }
            TableVisualisationEngine.CreateVisualTable();
        }
    }
}
