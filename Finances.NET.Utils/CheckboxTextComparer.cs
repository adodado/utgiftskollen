#region

using System.Collections;
using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils
{
    /// <summary>
    ///     Class CheckboxTextComparer.
    /// </summary>
    public class CheckboxTextComparer : IComparer
    {
        #region Fields

        /// <summary>
        ///     The object compare
        /// </summary>
        private readonly NumberCaseInsensitiveComparer ObjectCompare;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="CheckboxTextComparer" /> class.
        /// </summary>
        public CheckboxTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }

        #endregion

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
        public int Compare(object x, object y)
        {
            var listviewX = (ListViewItem) x;
            var listviewY = (ListViewItem) y;

            if (listviewX.Checked && !listviewY.Checked)
            {
                return -1;
            }
            if (listviewX.Checked.Equals(listviewY.Checked))
            {
                if (listviewX.ImageIndex < listviewY.ImageIndex)
                {
                    return -1;
                }
                if (listviewX.ImageIndex == listviewY.ImageIndex)
                {
                    return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim());
                }
                return 1;
            }
            return 1;
        }

        #endregion
    }
}