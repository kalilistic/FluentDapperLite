namespace FluentDapperLite.TypeHandler;

using System;
using System.Data;
using Dapper;

/// <summary>
/// Handles conversion between UInt64 and database types, inheriting from Dapper's SqlMapper.TypeHandler.
/// </summary>
public class UInt64Handler : SqlMapper.TypeHandler<ulong>
{
    public override void SetValue(IDbDataParameter parameter, ulong value) => parameter.Value = (decimal)value;

    public override ulong Parse(object value)
    {
        if (value is decimal decimalValue)
        {
            return (ulong)decimalValue;
        }

        if (value is long longValue)
        {
            return (ulong)longValue;
        }

        if (value is int intValue)
        {
            return (ulong)intValue;
        }

        throw new ArgumentException("Invalid value type");
    }
}
