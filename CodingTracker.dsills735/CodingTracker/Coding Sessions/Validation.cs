
using System.Globalization;

namespace CodingTracker.Coding_Sessions;

public class Validation
{
    public static bool TimeInputValidation(string time)
    {
        return DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        
    }
}
