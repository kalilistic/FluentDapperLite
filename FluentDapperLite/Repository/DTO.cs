// ReSharper disable InconsistentNaming
namespace FluentDapperLite.Repository;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents a Data Transfer Object with common identifiers and timestamps.
/// </summary>
[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "Not for DTO")]
public abstract class DTO
{
    public int id { get; set; }

    public long created { get; set; }

    public long updated { get; set; }
}
