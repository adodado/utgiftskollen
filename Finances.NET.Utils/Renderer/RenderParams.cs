#region

using System.Drawing;

#endregion



namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class RenderParams.
    /// </summary>
    public class RenderParams
    {
        #region Fields

        /// <summary>
        ///     The color table
        /// </summary>
        public object ColorTable;

        /// <summary>
        ///     The arrow dark
        /// </summary>
        public Color arrowDark;

        /// <summary>
        ///     The arrow disabled
        /// </summary>
        public Color arrowDisabled;

        /// <summary>
        ///     The arrow light
        /// </summary>
        public Color arrowLight;

        /// <summary>
        ///     The arrow selected
        /// </summary>
        public Color arrowSelected;

        /// <summary>
        ///     The border color1
        /// </summary>
        public Color borderColor1;

        /// <summary>
        ///     The border color2
        /// </summary>
        public Color borderColor2;

        /// <summary>
        ///     The check inset
        /// </summary>
        public int checkInset;

        /// <summary>
        ///     The context check border
        /// </summary>
        public Color contextCheckBorder;

        /// <summary>
        ///     The context check border selected
        /// </summary>
        public Color contextCheckBorderSelected;

        /// <summary>
        ///     The context check tick
        /// </summary>
        public Color contextCheckTick;

        /// <summary>
        ///     The context check tick selected
        /// </summary>
        public Color contextCheckTickSelected;

        /// <summary>
        ///     The context check tick thickness
        /// </summary>
        public float contextCheckTickThickness;

        /// <summary>
        ///     The context menu back
        /// </summary>
        public Color contextMenuBack;

        /// <summary>
        ///     The cut context menu
        /// </summary>
        public float cutContextMenu;

        /// <summary>
        ///     The cut menu item back
        /// </summary>
        public float cutMenuItemBack;

        /// <summary>
        ///     The cut tool item menu
        /// </summary>
        public float cutToolItemMenu;

        /// <summary>
        ///     The disabled border color1
        /// </summary>
        public Color disabledBorderColor1;

        /// <summary>
        ///     The disabled border color2
        /// </summary>
        public Color disabledBorderColor2;

        /// <summary>
        ///     The disabled fill bottom1
        /// </summary>
        public Color disabledFillBottom1;

        /// <summary>
        ///     The disabled fill bottom2
        /// </summary>
        public Color disabledFillBottom2;

        /// <summary>
        ///     The disabled fill top1
        /// </summary>
        public Color disabledFillTop1;

        /// <summary>
        ///     The disabled fill top2
        /// </summary>
        public Color disabledFillTop2;

        /// <summary>
        ///     The disabled inside bottom1
        /// </summary>
        public Color disabledInsideBottom1;

        /// <summary>
        ///     The disabled inside bottom2
        /// </summary>
        public Color disabledInsideBottom2;

        /// <summary>
        ///     The disabled inside top1
        /// </summary>
        public Color disabledInsideTop1;

        /// <summary>
        ///     The disabled inside top2
        /// </summary>
        public Color disabledInsideTop2;

        /// <summary>
        ///     The fill bottom1
        /// </summary>
        public Color fillBottom1;

        /// <summary>
        ///     The fill bottom2
        /// </summary>
        public Color fillBottom2;

        /// <summary>
        ///     The fill top1
        /// </summary>
        public Color fillTop1;

        /// <summary>
        ///     The fill top2
        /// </summary>
        public Color fillTop2;

        /// <summary>
        ///     The fore color
        /// </summary>
        public Color foreColor;

        /// <summary>
        ///     The grip dark
        /// </summary>
        public Color gripDark;

        /// <summary>
        ///     The grip light
        /// </summary>
        public Color gripLight;

        /// <summary>
        ///     The grip lines
        /// </summary>
        public int gripLines;

        /// <summary>
        ///     The grip move
        /// </summary>
        public int gripMove;

        /// <summary>
        ///     The grip offset
        /// </summary>
        public int gripOffset;

        /// <summary>
        ///     The grip size
        /// </summary>
        public int gripSize;

        /// <summary>
        ///     The grip square
        /// </summary>
        public int gripSquare;

        /// <summary>
        ///     The image margin
        /// </summary>
        public Color imageMargin;

        /// <summary>
        ///     The inside bottom1
        /// </summary>
        public Color insideBottom1;

        /// <summary>
        ///     The inside bottom2
        /// </summary>
        public Color insideBottom2;

        /// <summary>
        ///     The inside top1
        /// </summary>
        public Color insideTop1;

        /// <summary>
        ///     The inside top2
        /// </summary>
        public Color insideTop2;

        /// <summary>
        ///     The margin inset
        /// </summary>
        public int marginInset;

        /// <summary>
        ///     The separator inset
        /// </summary>
        public int separatorInset;

        /// <summary>
        ///     The separator menu dark
        /// </summary>
        public Color separatorMenuDark;

        /// <summary>
        ///     The separator menu light
        /// </summary>
        public Color separatorMenuLight;

        /// <summary>
        ///     The status strip border dark
        /// </summary>
        public Color statusStripBorderDark;

        /// <summary>
        ///     The status strip border light
        /// </summary>
        public Color statusStripBorderLight;

        /// <summary>
        ///     The text context menu item
        /// </summary>
        public Color textContextMenuItem;

        /// <summary>
        ///     The text disabled
        /// </summary>
        public Color textDisabled;

        /// <summary>
        ///     The text menu strip item
        /// </summary>
        public Color textMenuStripItem;

        /// <summary>
        ///     The text selected
        /// </summary>
        public Color textSelected;

        /// <summary>
        ///     The text status strip item
        /// </summary>
        public Color textStatusStripItem;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RenderParams" /> class.
        /// </summary>
        public RenderParams()
        {
            ColorTable = new TemplateColorTable();
        }

        #endregion Constructors
    }
}