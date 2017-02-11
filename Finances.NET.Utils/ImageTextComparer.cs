#region

using System.Collections;
using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils
{
    /// <summary>
    ///     Class ImageTextComparer.
    /// </summary>
    public class ImageTextComparer : IComparer
    {
        #region Fields

        /// <summary>
        ///     The _object compare
        /// </summary>
        private readonly NumberCaseInsensitiveComparer _objectCompare;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageTextComparer" /> class.
        /// </summary>
        public ImageTextComparer()
        {
            _objectCompare = new NumberCaseInsensitiveComparer();
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
            var image1 = listviewX.ImageIndex;
            var listviewY = (ListViewItem) y;
            var image2 = listviewY.ImageIndex;

            if (image1 < image2)
            {
                return -1;
            }
            return image1 == image2 ? _objectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim()) : 1;
        }

        #endregion
    }
}