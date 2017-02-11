#region

using System;
using System.Collections;
using System.Text.RegularExpressions;

#endregion

namespace Finances.NET.Utils
{
    /// <summary>
    ///     Class NumberCaseInsensitiveComparer.
    /// </summary>
    public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        #region Public methods

        /// <summary>
        ///     Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        ///     A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as
        ///     shown in the following table.Value Meaning Less than zero <paramref name="x" /> is less than <paramref name="y" />.
        ///     Zero <paramref name="x" /> equals <paramref name="y" />. Greater than zero <paramref name="x" /> is greater than
        ///     <paramref name="y" />.
        /// </returns>
        public new int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null && y != null)
            {
                return -1;
            }
            if (x != null && y == null)
            {
                return 1;
            }
            if ((x is String) && IsWholeNumber((string) x) && (y is String) && IsWholeNumber((string) y))
            {
                try
                {
                    return base.Compare(Convert.ToUInt64(((string) x).Trim()), Convert.ToUInt64(((string) y).Trim()));
                }
                catch
                {
                    return -1;
                }
            }
            return base.Compare(x, y);
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Check if the given number is a whole number.
        /// </summary>
        /// <param name="strNumber">Number</param>
        /// <returns>Number is whole</returns>
        private static bool IsWholeNumber(string strNumber)
        {
            var wholePattern = new Regex(@"^\d+$");
            return wholePattern.IsMatch(strNumber);
        }

        #endregion
    }
}