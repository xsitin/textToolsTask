using System.Data;
using System.Text;
using DataAccess;
using DataAccess.helpers;
using DataAccess.models;
using Microsoft.EntityFrameworkCore;
using TextStatisticCollector.utils;

namespace TextStatisticCollector;

public static class Application
{
    public static void Main(string[] args)
    {
        if (args.Length < 1 || args is ["-h"] or ["--help"])
        {
            PrintHelp();
            return;
        }

        var path = args[0];
        var statistic = GetStatistic(path);
        Console.WriteLine("File data processed!");
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

        Console.WriteLine("Db connected!");
        UploadStatistic(context, statistic);
    }

    private static void PrintHelp()
    {
        Console.WriteLine(
            "Usage: ./tsc.exe /path/to/file\n" +
            "Before use need to setup connection string for db in file appsettings.json or in environment variable ConnectionStrings__MsSqlDb");
    }

    private static void UploadStatistic(ApplicationContext context, Dictionary<string, int> statistic)
    {
        try
        {
            using var transaction = context.Database.BeginTransaction(IsolationLevel.Serializable);

            context.Database.ExecuteSql($"SELECT * FROM Words WITH (TABLOCKX)");

            foreach (var pair in statistic.Where(pair => pair.Value >= 4))
            {
                var wordModel = context.Words.Find(pair.Key);
                if (wordModel != null)
                    wordModel.count += pair.Value;
                else
                    context.Words.Add(new Word(pair.Key, pair.Value));
            }

            context.SaveChanges();
            transaction.Commit();
            Console.WriteLine("Data uploaded successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            Console.WriteLine("Press any key for close.");
            Console.ReadKey();
        }
    }


    private static Dictionary<string, int> GetStatistic(string pathToFile)
    {
        var text = File.ReadLines(pathToFile, Encoding.UTF8);
        IWordParser parser = new WordParser();
        var words = parser.GetWordsFromText(text);
        IWordStatisticCollector statisticCollector = new WordStatisticCollector();
        var statistic = statisticCollector.CollectStatistic(words);
        return statistic;
    }
}