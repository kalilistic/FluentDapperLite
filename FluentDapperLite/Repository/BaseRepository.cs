using System;
using System.Data;
using AutoMapper;

namespace FluentDapperLite.Repository;

/// <summary>
/// Provides a base repository class for common CRUD operations and utility methods.
/// </summary>
public abstract class BaseRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository"/> class.
    /// </summary>
    /// <param name="connection">An IDbConnection instance for database operations.</param>
    /// <param name="mapper">An IMapper instance for object mappings.</param>
    protected BaseRepository(IDbConnection connection, IMapper mapper)
    {
        this.Connection = connection;
        this.Mapper = mapper;
    }

    public IDbConnection Connection { get; }

    public IMapper Mapper { get; }

    /// <summary>
    /// Sets the creation and last-updated timestamps for the provided DTO.
    /// </summary>
    /// <param name="dto">Data Transfer Object.</param>
    protected static void SetCreateTimestamp(DTO dto)
    {
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        dto.created = currentTime;
        dto.updated = currentTime;
    }

    /// <summary>
    /// Sets the last-updated timestamp for the provided DTO.
    /// </summary>
    /// <param name="dto">Data Transfer Object.</param>
    protected static void SetUpdateTimestamp(DTO dto) => dto.updated = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}
