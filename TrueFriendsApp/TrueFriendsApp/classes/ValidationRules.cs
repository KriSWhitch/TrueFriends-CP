using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TrueFriendsApp
{
    public static class ValidationRules
    {
        public static bool FullNameValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(?i)[a-zа-я0-9-_\s]{3,40}$");
            return regex.IsMatch((string)value);
        }
        public static bool ShortNameValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(?i)[a-zа-я0-9-_\s]{3,20}$");
            return regex.IsMatch((string)value);
        }
        public static bool KindOfAnimalValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(?i)[a-zа-я0-9-_\s]{3,20}$");
            return regex.IsMatch((string)value);
        }
        public static bool DescriptionValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^(?i).{3,2000}$");
            return regex.IsMatch((string)value);
        }
        public static bool AnimalAgeValidation(object value)
        {
            Regex regex = new Regex(pattern: @"^\d{1,3}$");
            return regex.IsMatch((string)value);
        }
        public static bool AnimalWeightValidation(string value)
        {
            Regex regex = new Regex(pattern: @"^(\d{1,3}.\d{1})$|^(\d{1,3})$");
            return regex.IsMatch((string)value);
        }
    }
}
