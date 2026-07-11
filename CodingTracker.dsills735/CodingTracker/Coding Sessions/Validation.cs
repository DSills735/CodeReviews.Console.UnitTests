
using System.Globalization;

namespace CodingTracker.Coding_Sessions;

public class Validation
{
    public static bool TimeInputValidation(string time)
    {
        if (!DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}
