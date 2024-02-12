namespace DriverManagementSystem.Infrastructure.DataAccess;

public sealed class DriverQueries
{

    public static string CreateTable()
    {
        return @"
                CREATE TABLE IF NOT EXISTS Drivers (
                    Id INTEGER PRIMARY KEY,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    PhoneNumber TEXT NOT NULL
                );
            ";
    }

    public  string Delete() => "DELETE FROM Drivers WHERE Id = @Id;";

    public  string GetAll() => "SELECT * FROM Drivers;";

    public  string GetById() => "SELECT * FROM Drivers WHERE Id = @Id;";

    public  string Insert() => @"
            INSERT INTO Drivers (FirstName, LastName, Email, PhoneNumber)
            VALUES (@FirstName, @LastName, @Email, @PhoneNumber);
            SELECT last_insert_rowid();
        ";

    public  string Update() => @"
            UPDATE Drivers 
            SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber
            WHERE Id = @Id;
        ";
}
