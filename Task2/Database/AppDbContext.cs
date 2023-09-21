using Microsoft.EntityFrameworkCore;

using Task2.Common;
using Task2.Database.Entities;

namespace Task2.DB;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employee { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // NOTE: DB will be created in the bin directory of where the app is running from

        // Configure the database connection (e.g., SQLite, SQL Server, etc.)
        optionsBuilder.UseSqlite(Constants.SQL_LITE_DATA_SOURCE);
    }
}

