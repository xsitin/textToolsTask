using DataAccess.helpers;
using Microsoft.EntityFrameworkCore;

string connectionString;
try
{
    connectionString = AccessHelper.GetConnectionString();
}
catch (Exception e)
{
    Console.WriteLine("Error during parsing connection string:");
    Console.WriteLine(e);
    throw;
}

if (connectionString == null)
{
    var previousColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Connection string not found!");
    Console.ForegroundColor = previousColor;
    return;
}

using var context = AccessHelper.GetContext(connectionString);

try
{
    context.Database.EnsureCreated();
}
catch (Exception e)
{
    Console.WriteLine("Error during connection or checking db:");
    Console.WriteLine(e);
    throw;
}

Console.WriteLine("Enter empty string for exit");
var prefix = Console.ReadLine();
while (!string.IsNullOrWhiteSpace(prefix))
{
    var words = context.Words.AsNoTracking()
        .Where(x => x.word.StartsWith(prefix))
        .OrderByDescending(x => x.count)
        .ThenBy(x => x.word)
        .Take(5).ToArray();

    foreach (var word in words)
        Console.WriteLine($"{word.word}:{word.count}");
    prefix = Console.ReadLine();
}