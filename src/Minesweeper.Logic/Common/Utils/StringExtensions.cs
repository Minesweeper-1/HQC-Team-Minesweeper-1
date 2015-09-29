namespace Minesweeper.Logic.Common.Utils
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string[] SplitByUpperCase(this string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }
}
