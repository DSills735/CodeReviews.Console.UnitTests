
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingTracker.Coding_Sessions;

public class Validation
{
    static DateTime formattedTime;
    static bool valid = false;
    public static DateTime TimeInputValidation(string time)
    {
        while (!DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out formattedTime))
        {
            Console.WriteLine("Invalid format. Please enter the end Date and Time in the format (MM/DD/YYYY HH:MM)");
            time = Console.ReadLine()!;
            valid = false;

        }
        
        return formattedTime;
        
    }
}
