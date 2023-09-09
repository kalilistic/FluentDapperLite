# FluentDapperLite
[![Nuget](https://img.shields.io/nuget/v/FluentDapperLite)](https://www.nuget.org/packages/FluentDapperLite/)

A small helper library to use with [SQLite](https://www.sqlite.org), [Dapper](https://github.com/DapperLib/Dapper), [FluentMigrator](https://github.com/fluentmigrator/fluentmigrator), and [AutoMapper](https://github.com/AutoMapper/AutoMapper).

## Features
- Provide SQLite FluentMigrator Runner with common PRAGMA settings and normalized version naming scheme.
- Provide base data repository class providing fundamental methods for data access with AutoMapper.
- Provide FluentMigrator & Dapper extensions for UInt16 and UInt32 column types.
- Provide utility to check if a file is a valid SQLite database based on its binary signature.
- Provide FluentMigrator extensions for adding standard 'Id' and timestamp columns.

## Example

```csharp
// Check if valid SQLite database
bool isValid = SQLiteHelper.IsValidDatabase(dataSource);

// Run FluentMigrator to execute migrations found in calling assembly
FluentMigratorRunner.Run(dataSource);

// Build database connection
var databse = SQLiteDbConnectionBuilder.Build(dataSource);

// Build mapper with AutoMapper profile
var mapper = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MyProfile>();
}).CreateMapper();

// Build repository that inherits from BaseRepository
var myRepository = new MyRepository(database, mapper);
```