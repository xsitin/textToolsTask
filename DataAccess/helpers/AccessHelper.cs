using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.helpers;

public static class AccessHelper
{
    public static string? GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json")
            .Build();

        return configuration.GetConnectionString("MsSqlDb");
    }

    public static ApplicationContext GetContext(string connectionString1)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlServer(connectionString1);
        return new ApplicationContext(optionsBuilder.Options);
    }
}