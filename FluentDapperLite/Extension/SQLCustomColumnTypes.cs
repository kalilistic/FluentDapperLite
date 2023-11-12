namespace FluentDapperLite.Extension;

using FluentMigrator.Builders.Alter.Table;
using FluentMigrator.Builders.Create.Table;

/// <summary>
/// Provides custom column type extensions for FluentMigrator's table column creation and alteration syntax.
/// </summary>
/// <remarks>
/// This class extends FluentMigrator's ICreateTableColumnAsTypeSyntax and IAlterTableColumnAsTypeSyntax to add support for unsigned integer column types.
/// </remarks>
public static class SQLCustomColumnTypes
{
    /// <summary>
    /// Adds a column of type SMALLINT with a constraint to mimic UInt16.
    /// </summary>
    /// <param name="column">The ICreateTableColumnAsTypeSyntax instance to extend.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>An ICreateTableColumnOptionOrWithColumnSyntax instance with the added constraint.</returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax AsUInt16(this ICreateTableColumnAsTypeSyntax column, string columnName) => column.AsCustom($"SMALLINT CHECK({columnName} >= 0 AND {columnName} <= 65535)");

    /// <summary>
    /// Adds a column of type INTEGER with a constraint to mimic UInt32.
    /// </summary>
    /// <param name="column">The ICreateTableColumnAsTypeSyntax instance to extend.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>An ICreateTableColumnOptionOrWithColumnSyntax instance with the added constraint.</returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax AsUInt32(this ICreateTableColumnAsTypeSyntax column, string columnName) => column.AsCustom($"INTEGER CHECK({columnName} >= 0 AND {columnName} <= 4294967295)");

    /// <summary>
    /// Adds a column of type INTEGER with a constraint to mimic UInt64.
    /// Since SQLite uses dynamic typing, INTEGER can accommodate large integers, but care must be taken with values larger than 2^63 - 1.
    /// </summary>
    /// <param name="column">The ICreateTableColumnAsTypeSyntax instance to extend.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>An ICreateTableColumnOptionOrWithColumnSyntax instance with the added constraint.</returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax AsUInt64(this ICreateTableColumnAsTypeSyntax column, string columnName) => column.AsCustom($"INTEGER CHECK({columnName} >= 0)");

    /// <summary>
    /// Adds or alters a column of type SMALLINT with a constraint to mimic UInt16 in an existing table.
    /// </summary>
    /// <param name="column">The IAlterTableColumnAsTypeSyntax instance to extend.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>An IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax instance with the added constraint.</returns>
    public static IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax AsUInt16(this IAlterTableColumnAsTypeSyntax column, string columnName) => column.AsCustom($"SMALLINT CHECK({columnName} >= 0 AND {columnName} <= 65535)");

    /// <summary>
    /// Adds or alters a column of type INTEGER with a constraint to mimic UInt32 in an existing table.
    /// </summary>
    /// <param name="column">The IAlterTableColumnAsTypeSyntax instance to extend.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>An IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax instance with the added constraint.</returns>
    public static IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax AsUInt32(this IAlterTableColumnAsTypeSyntax column, string columnName) => column.AsCustom($"INTEGER CHECK({columnName} >= 0 AND {columnName} <= 4294967295)");

    /// <summary>
    /// Adds or alters a column of type INTEGER with a constraint to mimic UInt64 in an existing table.
    /// </summary>
    /// <param name="column">The IAlterTableColumnAsTypeSyntax instance to extend.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>An IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax instance with the added constraint.</returns>
    public static IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax AsUInt64(this IAlterTableColumnAsTypeSyntax column, string columnName) => column.AsCustom($"INTEGER CHECK({columnName} >= 0)");
}
