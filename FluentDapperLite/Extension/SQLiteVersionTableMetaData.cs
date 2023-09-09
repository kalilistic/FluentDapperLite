namespace FluentDapperLite.Extension;

using FluentMigrator.Runner.VersionTableInfo;

/// <summary>
/// Provides a custom implementation for version table metadata.
/// This class is used to configure versioning specifics of the database schema changes.
/// </summary>
/// <remarks>
/// Using this to set more consistent field naming conventions for the versioning table.
/// </remarks>
public class SQLiteVersionTableMetaData : IVersionTableMetaData
{
    public object ApplicationContext { get; set; } = null!;

    public string SchemaName => null!;

    public string TableName => "version_info";

    public string ColumnName => "version";

    public string UniqueIndexName => "idx_uc_version";

    public string DescriptionColumnName => "description";

    public string AppliedOnColumnName => "applied_on";

    public bool OwnsSchema => false;
}
