using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    public class Habit
    {
        public int id = 0;
        public string name = string.Empty;
        public string measurement = string.Empty;

        public Habit() { }

        public Habit(SqliteDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("id"));
            this.name = reader.GetString(reader.GetOrdinal("name"));
            this.measurement = reader.GetString(reader.GetOrdinal("measurement"));
        }

        public override string ToString()
        {
            return $"[#{id}] {name} (Measured in {measurement})";
        }
    }
}
