namespace FluentDapperLite.Runner;

using System.Reflection;
using Extension;
using FluentMigrator.Runner;
using FluentMigrator.Runner.VersionTableInfo;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides functionality to run Fluent Migrator migrations for SQLite databases.
/// </summary>
public static class SQLiteFluentMigratorRunner
{
    /// <summary>
    /// Runs the migration scripts located in the executing assembly, targeting the SQLite database specified by the data source.
    /// </summary>
    /// <param name="dataSource">The data source for the SQLite database.</param>
    public static void Run(string dataSource)
    {
        var connectionString = $"Data Source={dataSource};Version=3;";
        var services = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSQLite()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.GetCallingAssembly()).For.Migrations())
            .AddScoped<IVersionTableMetaData, SQLiteVersionTableMetaData>()
            .BuildServiceProvider();
        using var scope = services.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }
}
