#region

using System.Collections;
using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils
{
    /// <summary>
    ///     Class ListViewColumnSorter.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        #region Enum sort modifier

        /// <summary>
        ///     Enum SortModifiers
        /// </summary>
        public enum SortModifiers
        {
            /// <summary>
            ///     The sort by image
            /// </summary>
            SortByImage,

            /// <summary>
            ///     The sort by checkbox
            /// </summary>
            SortByCheckbox,

            /// <summary>
            ///     The sort by text
            /// </summary>
            SortByText
        }

        #endregion

        #region Fields

        /// <summary>
        ///     The first object compare
        /// </summary>
        private readonly ImageTextComparer FirstObjectCompare;

        /// <summary>
        ///     The first object compare2
        /// </summary>
        private readonly CheckboxTextComparer FirstObjectCompare2;

        /// <summary>
        ///     Case insensitive comparers
        /// </summary>
        private readonly NumberCaseInsensitiveComparer ObjectCompare;

        /// <summary>
        ///     My sort modifier
        /// </summary>
        private SortModifiers mySortModifier = SortModifiers.SortByText;

        #endregion

        #region Public properties

        /// <summary>
        ///     Column to sort
        /// </summary>
        public int ColumnToSort;

        /// <summary>
        ///     Order of sort
        /// </summary>
        public SortOrder OrderOfSort;

        /// <summary>
        ///     Gets or sets the _ sort modifier.
        /// </summary>
        /// <value>The _ sort modifier.</value>
        public SortModifiers _SortModifier
        {
            set { mySortModifier = value; }
            get { return mySortModifier; }
        }

        /// <summary>
        ///     Get or set the column to sort (default: 0)
        /// </summary>
        /// <value>The sort column.</value>
        public int SortColumn
        {
            set { ColumnToSort = value; }
            get { return ColumnToSort; }
        }

        /// <summary>
        ///     Get or set the sort order (default: ascending)
        /// </summary>
        /// <value>The order.</value>
        public SortOrder Order
        {
            set { OrderOfSort = value; }
            get { return OrderOfSort; }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new NumberCaseInsensitiveComparer();
            FirstObjectCompare = new ImageTextComparer();
            FirstObjectCompare2 = new CheckboxTextComparer();
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
            var compareResult = 0;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem) x;
            listviewY = (ListViewItem) y;

            var listViewMain = listviewX.ListView;

            if (listViewMain.Sorting != SortOrder.Ascending &&
                listViewMain.Sorting != SortOrder.Descending)
            {
                return compareResult;
            }

            if (mySortModifier.Equals(SortModifiers.SortByText) || ColumnToSort > 0)
            {
                if (listviewX.SubItems.Count <= ColumnToSort &&
                    listviewY.SubItems.Count <= ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(null, null);
                }
                else if (listviewX.SubItems.Count <= ColumnToSort &&
                         listviewY.SubItems.Count > ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(null, listviewY.SubItems[ColumnToSort].Text.Trim());
                }
                else if (listviewX.SubItems.Count > ColumnToSort && listviewY.SubItems.Count <= ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text.Trim(), null);
                }
                else
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text.Trim(),
                        listviewY.SubItems[ColumnToSort].Text.Trim());
                }
            }
            else
            {
                switch (mySortModifier)
                {
                    case SortModifiers.SortByCheckbox:
                        compareResult = FirstObjectCompare2.Compare(x, y);
                        break;
                    case SortModifiers.SortByImage:
                        compareResult = FirstObjectCompare.Compare(x, y);
                        break;
                    default:
                        compareResult = FirstObjectCompare.Compare(x, y);
                        break;
                }
            }

            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            return 0;
        }

        #endregion
    }
}