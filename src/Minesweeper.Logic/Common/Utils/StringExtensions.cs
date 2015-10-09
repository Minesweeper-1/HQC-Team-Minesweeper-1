namespace Minesweeper.Logic.Common.Utils
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class containing a string extension method
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// A string extension method splitting a string parameter by uppercase letters
        /// </summary>
        /// <param name="source">The string to be split</param>
        /// <returns>A string array of the parts of the split string</returns>
        public static string[] SplitByUpperCase(this string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }
}
