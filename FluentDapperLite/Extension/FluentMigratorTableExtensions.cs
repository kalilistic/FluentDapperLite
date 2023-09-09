namespace FluentDapperLite.Extension;

using FluentMigrator.Builders.Create.Table;

/// <summary>
/// Provides extension methods for FluentMigrator's ICreateTableWithColumnSyntax interface to simplify table creation.
/// </summary>
/// <remarks>
/// This class extends the ICreateTableWithColumnSyntax interface from FluentMigrator, offering methods to quickly add common columns like ID and timestamps.
/// </remarks>
public static class FluentMigratorTableExtensions
{
    /// <summary>
    /// Adds an 'id' column configured as a primary key with auto-incrementing values.
    /// </summary>
    /// <param name="tableWithColumnSyntax">The ICreateTableWithColumnSyntax instance.</param>
    /// <returns>The modified ICreateTableColumnOptionOrWithColumnSyntax instance.</returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax) => tableWithColumnSyntax
        .WithColumn("id")
        .AsInt32()
        .NotNullable()
        .PrimaryKey()
        .Identity();

    /// <summary>
    /// Adds 'created' and 'updated' columns configured as Int64 and not nullable.
    /// </summary>
    /// <param name="tableWithColumnSyntax">The ICreateTableWithColumnSyntax instance.</param>
    /// <returns>The modified ICreateTableWithColumnSyntax instance.</returns>
    public static ICreateTableWithColumnSyntax WithTimeStampColumns(this ICreateTableWithColumnSyntax tableWithColumnSyntax) => tableWithColumnSyntax
        .WithColumn("created").AsInt64().NotNullable()
        .WithColumn("updated").AsInt64().NotNullable();
}
