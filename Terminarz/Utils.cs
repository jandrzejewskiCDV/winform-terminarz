using System.Text;
using System.Text.RegularExpressions;

namespace Terminarz
{
    internal class Utils
    {
        public static string TrimInput(string input)
        {
            return input == null ? string.Empty : input.Trim();
        }

        public static bool NotEmptyAndAllLetters(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
        }

        public static bool IsValidPhoneNumber(string input)
        {
            return Regex.IsMatch(input, @"^\+?[0-9\s\-()]{7,20}$");
        }

        public static bool IsValidEmail(string input)
        {
            return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool AddTextToListBox(ListBox box, string input, Predicate<string> predicate, string errMessage)
        {
            input = TrimInput(input);

            if (box.Items.Contains(input))
                return false;

            if (!predicate(input))
            {
                MessageBox.Show(errMessage);
                return false;
            }

            box.Items.Add(input);
            return true;
        }

        public static bool RemoveSelectedTextFromListBox(ListBox box)
        {
            int selectedIndex = box.SelectedIndex;

            if (selectedIndex < 0)
                return false;

            box.Items.RemoveAt(selectedIndex);
            return true;
        }

        public static string JoinStringsFromListBox(ListBox box, string separator = ", ")
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < box.Items.Count; i++)
            {
                builder.Append(box.Items[i].ToString());

                if (i != box.Items.Count - 1)
                    builder.Append(separator);
            }

            return builder.ToString();
        }

        public static bool AreDateTimesEqualUpToMinutes(DateTime dt1, DateTime dt2)
        {
            return dt1.Year == dt2.Year
                && dt1.Month == dt2.Month
                && dt1.Day == dt2.Day
                && dt1.Hour == dt2.Hour
                && dt1.Minute == dt2.Minute;
        }
    }
}
