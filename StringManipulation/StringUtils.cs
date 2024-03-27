namespace StringManipulation;

public class StringUtils
{
    public static string timeConversion(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        string result = "";
        string strHour = s.Substring(0, 2);
        int hour = 0;
        string dayPeriod = s.Substring(s.Length - 2);

        if (string.Equals(dayPeriod, "AM"))
        {
            if (string.Equals(strHour, "12"))
            {
                strHour = "00";
            }
        }
        else
        {
            if (!string.Equals(strHour, "12"))
            {
                hour = Convert.ToInt32(strHour);
                hour += 12;
                strHour = hour.ToString("D2");
            }
        }

        result = strHour + s.Substring(2, s.Length - 4);

        return result;
    }
}
