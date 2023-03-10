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

    public static ApplicationContext GetContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new ApplicationContext(optionsBuilder.Options);
    }
}