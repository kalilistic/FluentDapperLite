using System.IO;
using System.Linq;

namespace FluentDapperLite.Validator;

/// <summary>
/// Provides utility methods for file operations, with a focus on SQLite database validation.
/// </summary>
/// <remarks>
/// This class contains methods for checking whether a given file path points to an SQLite database.
/// </remarks>
public class SQLiteFileValidator
{
    /// <summary>
    /// Validates whether the specified file is an SQLite database.
    /// </summary>
    /// <param name="path">The path of the file to validate.</param>
    /// <returns>True if the file is an SQLite database, otherwise false.</returns>
    public bool IsSQLiteDB(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }

        var sqliteSignature = new byte[] { 0x53, 0x51, 0x4C, 0x69, 0x74, 0x65, 0x20, 0x66, 0x6F, 0x72, 0x6D, 0x61, 0x74, 0x20, 0x33, 0x00 };
        using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        using var reader = new BinaryReader(fileStream);
        var buffer = reader.ReadBytes(16);

        return sqliteSignature.SequenceEqual(buffer);
    }
}
