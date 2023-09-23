using System.Collections.Generic;
using System.Data;

namespace FluentDapperLite.Maintenance;

/// <summary>
/// Provides methods for SQLite database management, tuning, and upkeep.
/// </summary>
public static class SQLiteDbMaintenance
{
    /// <summary>
    /// Runs the SQLite ANALYZE command to gather statistics about tables and indices.
    /// </summary>
    /// <param name="connection">The SQLite database connection.</param>
    public static void Analyze(IDbConnection connection) => ExecuteSimpleCommand(connection, "ANALYZE;");

    /// <summary>
    /// Runs the SQLite REINDEX command to rebuild indices.
    /// </summary>
    /// <param name="connection">The SQLite database connection.</param>
    public static void Reindex(IDbConnection connection) => ExecuteSimpleCommand(connection, "REINDEX;");

    /// <summary>
    /// Runs the SQLite VACUUM command to rebuild the database file, repacking it into a minimal amount of disk space.
    /// </summary>
    /// <param name="connection">The SQLite database connection.</param>
    public static void Vacuum(IDbConnection connection)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "VACUUM;";
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Runs the SQLite PRAGMA integrity_check command to check database for internal consistency.
    /// </summary>
    /// <param name="connection">The SQLite database connection.</param>
    /// <returns>A string containing the results of the integrity check.</returns>
    public static string CheckIntegrity(IDbConnection connection)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "PRAGMA integrity_check;";
        return cmd.ExecuteScalar()?.ToString() ?? "Unknown";
    }

    /// <summary>
    /// Runs the SQLite PRAGMA optimize command for potential automatic optimizations.
    /// </summary>
    /// <param name="connection">The SQLite database connection.</param>
    public static void Optimize(IDbConnection connection) => ExecuteSimpleCommand(connection, "PRAGMA optimize;");

    /// <summary>
    /// Resets internal caches for the SQLite database connection.
    /// </summary>
    /// <param name="connection">The SQLite database connection.</param>
    public static void ResetCache(IDbConnection connection) => ExecuteSimpleCommand(connection, "PRAGMA cache_reset;");

    private static void ExecuteSimpleCommand(IDbConnection connection, string commandText)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = commandText;
        cmd.ExecuteNonQuery();
    }
}
