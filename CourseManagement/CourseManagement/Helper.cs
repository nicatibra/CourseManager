using System.Text.RegularExpressions;

namespace CourseManagement
{
    internal static class Helper
    {
        public static bool CheckName(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= 3 && value.Length <= 25 && Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        public static string Capitalize(this string value)
        {
            return value.Trim().Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
        }
    }
}
