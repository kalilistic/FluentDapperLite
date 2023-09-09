using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FluentDapperLite.Extension;

/// <summary>
/// Provides methods for building and configuring SQLite database connections.
/// </summary>
public static class SQLiteDbConnectionBuilder
{
    public static IDbConnection Build(string dataFolder, string dbName = "data")
    {
        Directory.CreateDirectory(dataFolder);
        var connectionString = $"Data Source={Path.Combine(dataFolder, $"{dbName}.db")};";

        var connection = new SQLiteConnection(connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        ExecutePragmaCommand(cmd, "foreign_keys = ON");
        ExecutePragmaCommand(cmd, "journal_mode = WAL");
        ExecutePragmaCommand(cmd, "synchronous = NORMAL");
        ExecutePragmaCommand(cmd, "cache_size = 65536");

        return connection;
    }

    private static void ExecutePragmaCommand(IDbCommand cmd, string pragma)
    {
        cmd.CommandText = $"PRAGMA {pragma};";
        cmd.ExecuteNonQuery();
    }
}
