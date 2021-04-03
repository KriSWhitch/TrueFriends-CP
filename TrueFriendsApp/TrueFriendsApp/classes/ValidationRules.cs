using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TrueFriendsApp
{
    public static class ValidationRules
    {
        public static bool FullNameValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(?i)[a-zа-я0-9-_\s]{3,32}$");
            return regex.IsMatch((string)value);
        }
        public static bool ShortNameValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(?i)[a-zа-я0-9-_\s]{3,16}$");
            return regex.IsMatch((string)value);
        }
        public static bool RaitingValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(\d{1}.\d{1})$|^(\d{1}|1[0])$");
            return regex.IsMatch((string)value);
        }
        public static bool CostValidation(object value)
        {
            Regex regex = new Regex(pattern: @"(^\d*$)|(^(\d*[,]\d{1,2})$)");
            return regex.IsMatch((string)value);
        }
        public static bool AmountValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(\d{1,20})$");
            return regex.IsMatch((string)value);
        }
        public static bool CategoryValidation(string value)
        {
            if (value == null) return false;
            return (value.Length > 0);
        }
    }
}
