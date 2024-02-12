using DriverManagementSystem.Infrastructure.DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SQLitePCL;

namespace DriverManagementSystem.Infrastructure;

public class ApplicationDbContext
{

    public readonly SqliteConnection Connection;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Connection = new SqliteConnection(configuration.GetConnectionString("DefaultConnection"));

        Batteries.Init();

        Connection.Open();

        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var command = Connection.CreateCommand();
        command.CommandText = DriverQueries.CreateTable();
        command.ExecuteNonQuery();
    }

    public void Dispose()
    {
        Connection.Dispose();
    }
}
