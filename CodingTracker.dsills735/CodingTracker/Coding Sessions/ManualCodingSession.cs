using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Globalization;


public class ManualCodingSession
{
    static string? connectionStr = Program.config.GetConnectionString("DefaultConnection");
    internal static void ManualSession()
    {
        Console.Clear();
        Console.WriteLine("You are manually inputting a coding session. Please enter the start Date and Time (24 Hour). (MM/DD/YYYY HH:MM)");
        DateTime start;
        DateTime end;

        string startTime = Console.ReadLine()!;

        while (!CodingTracker.Coding_Sessions.Validation.TimeInputValidation(startTime))
        {
            Console.WriteLine("Invalid format. Please enter the start Date and Time in the format (MM/DD/YYYY HH:MM)");
            startTime = Console.ReadLine()!;
        }

        DateTime.TryParseExact(startTime, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out start);

        Console.WriteLine();
        Console.WriteLine("Enter the end Date and Time (24 Hour). (MM/DD/YYYY HH:MM)");
        string endTime = Console.ReadLine()!;

        while (!CodingTracker.Coding_Sessions.Validation.TimeInputValidation(endTime))
        {
            Console.WriteLine("Invalid format. Please enter the end Date and Time in the format (MM/DD/YYYY HH:MM)");
            endTime = Console.ReadLine()!;
        }
        DateTime.TryParseExact(endTime, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out end);

        TimeSpan duration = CalculateDuration.CalculateTimeDuration(start, end);

        String timeSpentCoding = CalculateDuration.TimeFormatter(duration);

        Console.WriteLine($"You coded for a total of {timeSpentCoding}. Great work!");

        using var connection = new SqliteConnection(connectionStr);
        connection.Open();
        DatabaseManager.AddRecordToDatabase(start, end, timeSpentCoding, connection);
        connection.Close();

        Program.MainMenu();
    }
}
