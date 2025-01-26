using System.Configuration;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker.Models;

internal class Database
{
    private string connectionString = ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString;
    private string tableName = "coding_sessions";

    internal Database()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            var command = $"CREATE TABLE IF NOT EXISTS {tableName}(id INTEGER PRIMARY KEY, start_time TEXT, end_time TEXT, duration TEXT)";
            connection.Execute(command);
        }
    }

    internal void AddSession(CodingSession session)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            var command = $"INSERT INTO {tableName} (start_time, end_time, duration) VALUES (@start_time, @end_time, @duration)";
            connection.Execute(command, new { start_time = session.StartTime, end_time = session.EndTime, duration = session.Duration });
        }
    }
}