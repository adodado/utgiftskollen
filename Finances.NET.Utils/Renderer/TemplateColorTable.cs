using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class TemplateColorTable.
    /// </summary>
    /// <remarks>Admir Cosic, 08-03-2014</remarks>
    internal class TemplateColorTable : ProfessionalColorTable
    {
        #region Fields

        /// <summary>
        ///     The _context menu back
        /// </summary>
        internal static Color _contextMenuBack = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button pressed begin
        /// </summary>
        internal static Color _buttonPressedBegin = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button pressed end
        /// </summary>
        internal static Color _buttonPressedEnd = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button pressed middle
        /// </summary>
        internal static Color _buttonPressedMiddle = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button selected begin
        /// </summary>
        internal static Color _buttonSelectedBegin = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button selected end
        /// </summary>
        internal static Color _buttonSelectedEnd = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button selected middle
        /// </summary>
        internal static Color _buttonSelectedMiddle = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _menu item selected begin
        /// </summary>
        internal static Color _menuItemSelectedBegin = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _menu item selected end
        /// </summary>
        internal static Color _menuItemSelectedEnd = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _check back
        /// </summary>
        internal static Color _checkBack = Color.Transparent;
        /// <summary>
        ///     The _grip dark
        /// </summary>
        internal static Color _gripDark = Color.FromArgb(160, 160, 160);
        /// <summary>
        ///     The _grip light
        /// </summary>
        internal static Color _gripLight = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _image margin
        /// </summary>
        public static Color _imageMargin = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _menu border
        /// </summary>
        internal static Color _menuBorder = Color.FromArgb(160, 160, 160);
        /// <summary>
        ///     The _overflow begin
        /// </summary>
        internal static Color _overflowBegin = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _overflow end
        /// </summary>
        internal static Color _overflowEnd = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _overflow middle
        /// </summary>
        internal static Color _overflowMiddle = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _menu tool back
        /// </summary>
        internal static Color _menuToolBack = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _separator dark
        /// </summary>
        internal static Color _separatorDark = Color.FromArgb(160, 160, 160);
        /// <summary>
        ///     The _separator light
        /// </summary>
        internal static Color _separatorLight = Color.Transparent;
        /// <summary>
        ///     The _status strip light
        /// </summary>
        internal static Color _statusStripLight = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _status strip dark
        /// </summary>
        internal static Color _statusStripDark = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _tool strip border
        /// </summary>
        internal static Color _toolStripBorder = Color.FromArgb(160, 160, 160);
        /// <summary>
        ///     The _tool strip content end
        /// </summary>
        internal static Color _toolStripContentEnd = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _tool strip begin
        /// </summary>
        internal static Color _toolStripBegin = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _tool strip end
        /// </summary>
        internal static Color _toolStripEnd = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _tool strip middle
        /// </summary>
        internal static Color _toolStripMiddle = Color.FromArgb(255, 255, 255);
        /// <summary>
        ///     The _button border
        /// </summary>
        internal static Color _buttonBorder = Color.FromArgb(229, 195, 101);

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets the starting color of the gradient used when the button is pressed.
        /// </summary>
        /// <value>The button pressed gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used when the button is
        ///     pressed.
        /// </returns>
        public override Color ButtonPressedGradientBegin
        {
            get { return _buttonPressedBegin; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used when the button is pressed.
        /// </summary>
        /// <value>The button pressed gradient end.</value>
        /// <returns>A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used when the button is pressed.</returns>
        public override Color ButtonPressedGradientEnd
        {
            get { return _buttonPressedEnd; }
        }

        /// <summary>
        ///     Gets the middle color of the gradient used when the button is pressed.
        /// </summary>
        /// <value>The button pressed gradient middle.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the middle color of the gradient used when the button is
        ///     pressed.
        /// </returns>
        public override Color ButtonPressedGradientMiddle
        {
            get { return _buttonPressedMiddle; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used when the button is
        ///     selected.
        /// </returns>
        public override Color ButtonSelectedGradientBegin
        {
            get { return _buttonSelectedBegin; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used when the button is
        ///     selected.
        /// </returns>
        public override Color ButtonSelectedGradientEnd
        {
            get { return _buttonSelectedEnd; }
        }

        /// <summary>
        ///     Gets the middle color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected gradient middle.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the middle color of the gradient used when the button is
        ///     selected.
        /// </returns>
        public override Color ButtonSelectedGradientMiddle
        {
            get { return _buttonSelectedMiddle; }
        }

        /// <summary>
        ///     Gets the border color to use with
        ///     <see cref="P:System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight" />.
        /// </summary>
        /// <value>The button selected highlight border.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the border color to use with
        ///     <see cref="P:System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight" />.
        /// </returns>
        public override Color ButtonSelectedHighlightBorder
        {
            get { return _buttonBorder; }
        }

        /// <summary>
        ///     Gets the solid color to use when the button is checked and gradients are being used.
        /// </summary>
        /// <value>The check background.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the solid color to use when the button is checked and
        ///     gradients are being used.
        /// </returns>
        public override Color CheckBackground
        {
            get { return _checkBack; }
        }

        /// <summary>
        ///     Gets the color to use for shadow effects on the grip (move handle).
        /// </summary>
        /// <value>The grip dark.</value>
        /// <returns>A <see cref="T:System.Drawing.Color" /> that is the color to use for shadow effects on the grip (move handle).</returns>
        public override Color GripDark
        {
            get { return _gripDark; }
        }

        /// <summary>
        ///     Gets the color to use for highlight effects on the grip (move handle).
        /// </summary>
        /// <value>The grip light.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the color to use for highlight effects on the grip (move
        ///     handle).
        /// </returns>
        public override Color GripLight
        {
            get { return _gripLight; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the image margin of a
        ///     <see cref="T:System.Windows.Forms.ToolStripDropDownMenu" />.
        /// </summary>
        /// <value>The image margin gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the image margin of
        ///     a <see cref="T:System.Windows.Forms.ToolStripDropDownMenu" />.
        /// </returns>
        public override Color ImageMarginGradientBegin
        {
            get { return _imageMargin; }
        }

        /// <summary>
        ///     Gets the color that is the border color to use on a <see cref="T:System.Windows.Forms.MenuStrip" />.
        /// </summary>
        /// <value>The menu border.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the border color to use on a
        ///     <see cref="T:System.Windows.Forms.MenuStrip" />.
        /// </returns>
        public override Color MenuBorder
        {
            get { return _menuBorder; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used when a top-level
        ///     <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is pressed.
        /// </summary>
        /// <value>The menu item pressed gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used when a top-level
        ///     <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is pressed.
        /// </returns>
        public override Color MenuItemPressedGradientBegin
        {
            get { return _toolStripBegin; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used when a top-level <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is
        ///     pressed.
        /// </summary>
        /// <value>The menu item pressed gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used when a top-level
        ///     <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is pressed.
        /// </returns>
        public override Color MenuItemPressedGradientEnd
        {
            get { return _toolStripEnd; }
        }

        /// <summary>
        ///     Gets the middle color of the gradient used when a top-level <see cref="T:System.Windows.Forms.ToolStripMenuItem" />
        ///     is pressed.
        /// </summary>
        /// <value>The menu item pressed gradient middle.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the middle color of the gradient used when a top-level
        ///     <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is pressed.
        /// </returns>
        public override Color MenuItemPressedGradientMiddle
        {
            get { return _toolStripMiddle; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used when the <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is
        ///     selected.
        /// </summary>
        /// <value>The menu item selected gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used when the
        ///     <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is selected.
        /// </returns>
        public override Color MenuItemSelectedGradientBegin
        {
            get { return _menuItemSelectedBegin; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used when the <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is
        ///     selected.
        /// </summary>
        /// <value>The menu item selected gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used when the
        ///     <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is selected.
        /// </returns>
        public override Color MenuItemSelectedGradientEnd
        {
            get { return _menuItemSelectedEnd; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.MenuStrip" />.
        /// </summary>
        /// <value>The menu strip gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.MenuStrip" />.
        /// </returns>
        public override Color MenuStripGradientBegin
        {
            get { return _menuToolBack; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.MenuStrip" />.
        /// </summary>
        /// <value>The menu strip gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.MenuStrip" />.
        /// </returns>
        public override Color MenuStripGradientEnd
        {
            get { return _menuToolBack; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton" />.
        /// </summary>
        /// <value>The overflow button gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripOverflowButton" />.
        /// </returns>
        public override Color OverflowButtonGradientBegin
        {
            get { return _overflowBegin; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton" />.
        /// </summary>
        /// <value>The overflow button gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripOverflowButton" />.
        /// </returns>
        public override Color OverflowButtonGradientEnd
        {
            get { return _overflowEnd; }
        }

        /// <summary>
        ///     Gets the middle color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton" />.
        /// </summary>
        /// <value>The overflow button gradient middle.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the middle color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripOverflowButton" />.
        /// </returns>
        public override Color OverflowButtonGradientMiddle
        {
            get { return _overflowMiddle; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripContainer" />.
        /// </summary>
        /// <value>The rafting container gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripContainer" />.
        /// </returns>
        public override Color RaftingContainerGradientBegin
        {
            get { return _menuToolBack; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripContainer" />.
        /// </summary>
        /// <value>The rafting container gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripContainer" />.
        /// </returns>
        public override Color RaftingContainerGradientEnd
        {
            get { return _menuToolBack; }
        }

        /// <summary>
        ///     Gets the color to use to for shadow effects on the <see cref="T:System.Windows.Forms.ToolStripSeparator" />.
        /// </summary>
        /// <value>The separator dark.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the color to use to for shadow effects on the
        ///     <see cref="T:System.Windows.Forms.ToolStripSeparator" />.
        /// </returns>
        public override Color SeparatorDark
        {
            get { return _separatorDark; }
        }

        /// <summary>
        ///     Gets the color to use to for highlight effects on the <see cref="T:System.Windows.Forms.ToolStripSeparator" />.
        /// </summary>
        /// <value>The separator light.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the color to use to for highlight effects on the
        ///     <see cref="T:System.Windows.Forms.ToolStripSeparator" />.
        /// </returns>
        public override Color SeparatorLight
        {
            get { return _separatorLight; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used on the <see cref="T:System.Windows.Forms.StatusStrip" />.
        /// </summary>
        /// <value>The status strip gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used on the
        ///     <see cref="T:System.Windows.Forms.StatusStrip" />.
        /// </returns>
        public override Color StatusStripGradientBegin
        {
            get { return _statusStripLight; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used on the <see cref="T:System.Windows.Forms.StatusStrip" />.
        /// </summary>
        /// <value>The status strip gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used on the
        ///     <see cref="T:System.Windows.Forms.StatusStrip" />.
        /// </returns>
        public override Color StatusStripGradientEnd
        {
            get { return _statusStripDark; }
        }

        /// <summary>
        ///     Gets the border color to use on the bottom edge of the <see cref="T:System.Windows.Forms.ToolStrip" />.
        /// </summary>
        /// <value>The tool strip border.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the border color to use on the bottom edge of the
        ///     <see cref="T:System.Windows.Forms.ToolStrip" />.
        /// </returns>
        public override Color ToolStripBorder
        {
            get { return _toolStripBorder; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripContentPanel" />.
        /// </summary>
        /// <value>The tool strip content panel gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripContentPanel" />.
        /// </returns>
        public override Color ToolStripContentPanelGradientBegin
        {
            get { return _toolStripContentEnd; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripContentPanel" />.
        /// </summary>
        /// <value>The tool strip content panel gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripContentPanel" />.
        /// </returns>
        public override Color ToolStripContentPanelGradientEnd
        {
            get { return _menuToolBack; }
        }

        /// <summary>
        ///     Gets the solid background color of the <see cref="T:System.Windows.Forms.ToolStripDropDown" />.
        /// </summary>
        /// <value>The tool strip drop down background.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the solid background color of the
        ///     <see cref="T:System.Windows.Forms.ToolStripDropDown" />.
        /// </returns>
        public override Color ToolStripDropDownBackground
        {
            get { return _contextMenuBack; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </summary>
        /// <value>The tool strip gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </returns>
        public override Color ToolStripGradientBegin
        {
            get { return _toolStripBegin; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </summary>
        /// <value>The tool strip gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </returns>
        public override Color ToolStripGradientEnd
        {
            get { return _toolStripEnd; }
        }

        /// <summary>
        ///     Gets the middle color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </summary>
        /// <value>The tool strip gradient middle.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the middle color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </returns>
        public override Color ToolStripGradientMiddle
        {
            get { return _toolStripMiddle; }
        }

        /// <summary>
        ///     Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripPanel" />.
        /// </summary>
        /// <value>The tool strip panel gradient begin.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the starting color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripPanel" />.
        /// </returns>
        public override Color ToolStripPanelGradientBegin
        {
            get { return _menuToolBack; }
        }

        /// <summary>
        ///     Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripPanel" />.
        /// </summary>
        /// <value>The tool strip panel gradient end.</value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that is the end color of the gradient used in the
        ///     <see cref="T:System.Windows.Forms.ToolStripPanel" />.
        /// </returns>
        public override Color ToolStripPanelGradientEnd
        {
            get { return _menuToolBack; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemplateColorTable" /> class.
        /// </summary>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        [DebuggerNonUserCode]
        public TemplateColorTable()
        {
        }

        #endregion Constructors
    }
}
