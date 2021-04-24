using System;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TrueFriendsApp
{
    public static class ValidationRules
    {
        public static bool NameValidation(object value)
        {
            return Regex.IsMatch((string)value, @"^(?i)[a-zа-я0-9-_\s]{3,32}$");
        }
        public static bool KindOfAnimalValidation(object value)
        {
            return Regex.IsMatch((string)value, @"^(?i)[a-zа-я0-9-_\s]{3,20}$");
        }
        public static bool DescriptionValidation(object value)
        {
            return Regex.IsMatch((string)value, @"^(?i).{3,2000}$");
        }
        public static bool AnimalAgeValidation(object value)
        {
            return Regex.IsMatch((string)value, @"^\d{1,3}$");
        }
        public static bool AnimalWeightValidation(object value)
        {
            return Regex.IsMatch((string)value, @"^(\d{1,3}.\d{1,2})$|^(\d{1,3})$");
        }
        public static bool IsLoginValid(object value)
        {
            return Regex.IsMatch((string)value, @"^(?i)[a-z0-9]{3,20}$");
        }
        public static bool IsPasswordValid(object value)
        {
            return Regex.IsMatch((string)value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{4,30}$");
        }
    }
}
