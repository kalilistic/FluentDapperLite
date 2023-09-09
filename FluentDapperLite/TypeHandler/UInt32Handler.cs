namespace FluentDapperLite.TypeHandler;

using System;
using System.Data;
using global::Dapper;

/// <summary>
/// Handles conversion between UInt32 and database types, inheriting from Dapper's SqlMapper.TypeHandler.
/// </summary>
public class UInt32Handler : SqlMapper.TypeHandler<uint>
{
    /// <inheritdoc />
    public override void SetValue(IDbDataParameter parameter, uint value) => parameter.Value = (long)value;

    /// <inheritdoc />
    public override uint Parse(object value)
    {
        if (value is long longValue)
        {
            return (uint)longValue;
        }

        if (value is int intValue)
        {
            return (uint)intValue;
        }

        throw new ArgumentException("Invalid value type");
    }
}
