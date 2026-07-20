
using System.Globalization;

namespace CodingTracker.Coding_Sessions;

public class Validation
{
    public static bool TimeInputValidation(string time)
    {
        return DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        
    }

    public static bool YorNValidation(string input)
    {
        if(input.Trim().ToLower() == "y" || input.Trim().ToLower() == "n")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
