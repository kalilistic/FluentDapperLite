namespace FluentDapperLite.TypeHandler;

using System;
using System.Data;
using global::Dapper;

/// <summary>
/// Handles conversion between UInt16 and database types, inheriting from Dapper's SqlMapper.TypeHandler.
/// </summary>
public class UInt16Handler : SqlMapper.TypeHandler<ushort>
{
    /// <inheritdoc />
    public override void SetValue(IDbDataParameter parameter, ushort value) => parameter.Value = (long)value;

    /// <inheritdoc />
    public override ushort Parse(object value)
    {
        if (value is long longValue)
        {
            return (ushort)longValue;
        }

        if (value is int intValue)
        {
            return (ushort)intValue;
        }

        throw new ArgumentException("Invalid value type");
    }
}
