#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class TemplateRenderer.
    /// </summary>
    /// <remarks>Admir Cosic, 08-03-2014</remarks>
    internal class TemplateRenderer : ToolStripProfessionalRenderer
    {
        #region Classes

        /// <summary>
        ///     Class GradientItemColors.
        /// </summary>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        private class GradientItemColors
        {
            #region Fields

            /// <summary>
            ///     The c border1
            /// </summary>
            public readonly Color cBorder1;

            /// <summary>
            ///     The c border2
            /// </summary>
            public readonly Color cBorder2;

            /// <summary>
            ///     The c fill bottom1
            /// </summary>
            public readonly Color cFillBottom1;

            /// <summary>
            ///     The c fill bottom2
            /// </summary>
            public readonly Color cFillBottom2;

            /// <summary>
            ///     The c fill top1
            /// </summary>
            public readonly Color cFillTop1;

            /// <summary>
            ///     The c fill top2
            /// </summary>
            public readonly Color cFillTop2;

            /// <summary>
            ///     The c inside bottom1
            /// </summary>
            public readonly Color cInsideBottom1;

            /// <summary>
            ///     The c inside bottom2
            /// </summary>
            public readonly Color cInsideBottom2;

            /// <summary>
            ///     The c inside top1
            /// </summary>
            public readonly Color cInsideTop1;

            /// <summary>
            ///     The c inside top2
            /// </summary>
            public readonly Color cInsideTop2;

            #endregion Fields

            #region Constructors

            /// <summary>
            ///     Initializes a new instance of the <see cref="GradientItemColors" /> class.
            /// </summary>
            /// <param name="insideTop1">The inside top1.</param>
            /// <param name="insideTop2">The inside top2.</param>
            /// <param name="insideBottom1">The inside bottom1.</param>
            /// <param name="insideBottom2">The inside bottom2.</param>
            /// <param name="fillTop1">The fill top1.</param>
            /// <param name="fillTop2">The fill top2.</param>
            /// <param name="fillBottom1">The fill bottom1.</param>
            /// <param name="fillBottom2">The fill bottom2.</param>
            /// <param name="border1">The border1.</param>
            /// <param name="border2">The border2.</param>
            /// <remarks>Admir Cosic, 08-03-2014</remarks>
            public GradientItemColors(Color insideTop1, Color insideTop2, Color insideBottom1, Color insideBottom2,
                Color fillTop1, Color fillTop2, Color fillBottom1, Color fillBottom2, Color border1, Color border2)
            {
                cInsideTop1 = insideTop1;
                cInsideTop2 = insideTop2;
                cInsideBottom1 = insideBottom1;
                cInsideBottom2 = insideBottom2;
                cFillTop1 = fillTop1;
                cFillTop2 = fillTop2;
                cFillBottom1 = fillBottom1;
                cFillBottom2 = fillBottom2;
                cBorder1 = border1;
                cBorder2 = border2;
            }

            #endregion Constructors
        }

        #endregion Classes

        #region Fields

        /// <summary>
        ///     The _grip offset
        /// </summary>
        private static int _gripOffset;

        /// <summary>
        ///     The _grip square
        /// </summary>
        private static int _gripSquare;

        /// <summary>
        ///     The _grip size
        /// </summary>
        private static int _gripSize;

        /// <summary>
        ///     The _grip move
        /// </summary>
        private static int _gripMove;

        /// <summary>
        ///     The _grip lines
        /// </summary>
        private static int _gripLines;

        /// <summary>
        ///     The _check inset
        /// </summary>
        private static int _checkInset;

        /// <summary>
        ///     The _margin inset
        /// </summary>
        private static int _marginInset;

        /// <summary>
        ///     The _separator inset
        /// </summary>
        private static int _separatorInset;

        /// <summary>
        ///     The _cut tool item menu
        /// </summary>
        private static float _cutToolItemMenu;

        /// <summary>
        ///     The _cut context menu
        /// </summary>
        private static float _cutContextMenu;

        /// <summary>
        ///     The _cut menu item back
        /// </summary>
        private static float _cutMenuItemBack;

        /// <summary>
        ///     The _context check tick thickness
        /// </summary>
        private static float _contextCheckTickThickness;

        /// <summary>
        ///     The _status strip blend
        /// </summary>
        private static Blend _statusStripBlend;

        /// <summary>
        ///     The color table
        /// </summary>
        internal new static ProfessionalColorTable ColorTable;

        /// <summary>
        ///     The inside top1
        /// </summary>
        internal static Color InsideTop1;

        /// <summary>
        ///     The inside top2
        /// </summary>
        internal static Color InsideTop2;

        /// <summary>
        ///     The inside bottom1
        /// </summary>
        internal static Color insideBottom1;

        /// <summary>
        ///     The inside bottom2
        /// </summary>
        internal static Color insideBottom2;

        /// <summary>
        ///     The fill top1
        /// </summary>
        internal static Color fillTop1;

        /// <summary>
        ///     The fill top2
        /// </summary>
        internal static Color fillTop2;

        /// <summary>
        ///     The fill bottom1
        /// </summary>
        internal static Color fillBottom1;

        /// <summary>
        ///     The fill bottom2
        /// </summary>
        internal static Color fillBottom2;

        /// <summary>
        ///     The border color1
        /// </summary>
        internal static Color borderColor1;

        /// <summary>
        ///     The border color2
        /// </summary>
        internal static Color borderColor2;

        /// <summary>
        ///     The disabled inside top1
        /// </summary>
        internal static Color disabledInsideTop1;

        /// <summary>
        ///     The disabled inside top2
        /// </summary>
        internal static Color disabledInsideTop2;

        /// <summary>
        ///     The disabled inside bottom1
        /// </summary>
        internal static Color disabledInsideBottom1;

        /// <summary>
        ///     The disabled inside bottom2
        /// </summary>
        internal static Color disabledInsideBottom2;

        /// <summary>
        ///     The disabled fill top1
        /// </summary>
        internal static Color disabledFillTop1;

        /// <summary>
        ///     The disabled fill top2
        /// </summary>
        internal static Color disabledFillTop2;

        /// <summary>
        ///     The disabled fill bottom1
        /// </summary>
        internal static Color disabledFillBottom1;

        /// <summary>
        ///     The disabled fill bottom2
        /// </summary>
        internal static Color disabledFillBottom2;

        /// <summary>
        ///     The disabled border color1
        /// </summary>
        internal static Color disabledBorderColor1;

        /// <summary>
        ///     The disabled border color2
        /// </summary>
        internal static Color disabledBorderColor2;

        /// <summary>
        ///     The _text disabled
        /// </summary>
        internal static Color _textDisabled;

        /// <summary>
        ///     The _text menu strip item
        /// </summary>
        internal static Color _textMenuStripItem;

        /// <summary>
        ///     The _text status strip item
        /// </summary>
        internal static Color _textStatusStripItem;

        /// <summary>
        ///     The _text context menu item
        /// </summary>
        internal static Color _textContextMenuItem;

        /// <summary>
        ///     The _text selected
        /// </summary>
        internal static Color _textSelected;

        /// <summary>
        ///     The _arrow disabled
        /// </summary>
        internal static Color _arrowDisabled;

        /// <summary>
        ///     The _arrow light
        /// </summary>
        internal static Color _arrowLight;

        /// <summary>
        ///     The _arrow dark
        /// </summary>
        internal static Color _arrowDark;

        /// <summary>
        ///     The _arrow selected
        /// </summary>
        internal static Color _arrowSelected;

        /// <summary>
        ///     The _separator menu light
        /// </summary>
        internal static Color _separatorMenuLight;

        /// <summary>
        ///     The _separator menu dark
        /// </summary>
        internal static Color _separatorMenuDark;

        /// <summary>
        ///     The _context menu back
        /// </summary>
        internal static Color _contextMenuBack;

        /// <summary>
        ///     The _context check border
        /// </summary>
        internal static Color _contextCheckBorder;

        /// <summary>
        ///     The _context check border selected
        /// </summary>
        internal static Color _contextCheckBorderSelected;

        /// <summary>
        ///     The _context check tick
        /// </summary>
        internal static Color _contextCheckTick;

        /// <summary>
        ///     The _context check tick selected
        /// </summary>
        internal static Color _contextCheckTickSelected;

        /// <summary>
        ///     The _status strip border dark
        /// </summary>
        internal static Color _statusStripBorderDark;

        /// <summary>
        ///     The _status strip border light
        /// </summary>
        internal static Color _statusStripBorderLight;

        /// <summary>
        ///     The _grip dark
        /// </summary>
        internal static Color _gripDark;

        /// <summary>
        ///     The _grip light
        /// </summary>
        internal static Color _gripLight;

        /// <summary>
        ///     The _item context item enabled colors
        /// </summary>
        private static GradientItemColors _itemContextItemEnabledColors;

        /// <summary>
        ///     The _item disabled colors
        /// </summary>
        private static GradientItemColors _itemDisabledColors;

        /// <summary>
        ///     The _item tool item selected colors
        /// </summary>
        private static GradientItemColors _itemToolItemSelectedColors;

        /// <summary>
        ///     The _item tool item pressed colors
        /// </summary>
        private static GradientItemColors _itemToolItemPressedColors;

        /// <summary>
        ///     The _item tool item checked colors
        /// </summary>
        private static GradientItemColors _itemToolItemCheckedColors;

        /// <summary>
        ///     The _item tool item check press colors
        /// </summary>
        private static GradientItemColors _itemToolItemCheckPressColors;

        /// <summary>
        ///     The forecolor
        /// </summary>
        private readonly Color forecolor;

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is glass desired.
        /// </summary>
        /// <value><c>true</c> if this instance is glass desired; otherwise, <c>false</c>.</value>
        public bool IsGlassDesired { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemplateRenderer" /> class.
        /// </summary>
        /// <param name="params">The parameters.</param>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        public TemplateRenderer(RenderParams @params)
        {
            RoundedEdges = false;
            forecolor = @params.foreColor;
            _gripOffset = @params.gripOffset;
            _gripSquare = @params.gripSquare;
            _gripSize = @params.gripSize;
            _gripMove = @params.gripMove;
            _gripLines = @params.gripLines;
            _checkInset = @params.checkInset;
            _marginInset = @params.marginInset;
            _separatorInset = @params.separatorInset;
            _cutToolItemMenu = @params.cutToolItemMenu;
            _cutContextMenu = @params.cutContextMenu;
            _cutMenuItemBack = @params.cutMenuItemBack;
            _contextCheckTickThickness = @params.contextCheckTickThickness;
            ColorTable = (ProfessionalColorTable) @params.ColorTable;
            TemplateColorTable._imageMargin = @params.imageMargin;
            InsideTop1 = @params.insideTop1;
            InsideTop2 = @params.insideTop2;
            insideBottom1 = @params.insideBottom1;
            insideBottom2 = @params.insideBottom2;
            fillTop1 = @params.fillTop1;
            fillTop2 = @params.fillTop2;
            fillBottom1 = @params.fillBottom1;
            fillBottom2 = @params.fillBottom2;
            borderColor1 = @params.borderColor1;
            borderColor2 = @params.borderColor2;
            disabledInsideTop1 = @params.disabledInsideTop1;
            disabledInsideTop2 = @params.disabledInsideTop2;
            disabledInsideBottom1 = @params.disabledInsideBottom1;
            disabledInsideBottom2 = @params.disabledInsideBottom2;
            disabledFillTop1 = @params.disabledFillTop1;
            disabledFillTop2 = @params.disabledFillTop2;
            disabledFillBottom1 = @params.disabledFillBottom1;
            disabledFillBottom2 = @params.disabledFillBottom2;
            disabledBorderColor1 = @params.disabledBorderColor1;
            disabledBorderColor2 = @params.disabledBorderColor2;
            _textDisabled = @params.textDisabled;
            _textMenuStripItem = @params.textMenuStripItem;
            _textStatusStripItem = @params.textStatusStripItem;
            _textContextMenuItem = @params.textContextMenuItem;
            _textSelected = @params.textSelected;
            _arrowDisabled = @params.arrowDisabled;
            _arrowLight = @params.arrowLight;
            _arrowDark = @params.arrowDark;
            _arrowSelected = @params.arrowSelected;
            _separatorMenuLight = @params.separatorMenuLight;
            _separatorMenuDark = @params.separatorMenuDark;
            _contextMenuBack = @params.contextMenuBack;
            _contextCheckBorder = @params.contextCheckBorder;
            _contextCheckBorderSelected = @params.contextCheckBorderSelected;
            _contextCheckTick = @params.contextCheckTick;
            _contextCheckTickSelected = @params.contextCheckTickSelected;
            _statusStripBorderDark = @params.statusStripBorderDark;
            _statusStripBorderLight = @params.statusStripBorderLight;
            _gripDark = @params.gripDark;
            _gripLight = @params.gripLight;
            _itemContextItemEnabledColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
                @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
                @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            _itemDisabledColors = new GradientItemColors(@params.disabledInsideTop1, @params.disabledInsideTop2,
                @params.disabledInsideBottom1, @params.disabledInsideBottom2, @params.disabledFillTop1,
                @params.disabledFillTop2, @params.disabledFillBottom1, @params.disabledFillBottom2,
                @params.disabledBorderColor1, @params.disabledBorderColor2);
            _itemToolItemSelectedColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
                @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
                @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            _itemToolItemPressedColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
                @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
                @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            _itemToolItemCheckedColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
                @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
                @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            _itemToolItemCheckPressColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
                @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
                @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            _statusStripBlend = new Blend();
            _statusStripBlend.Positions = new[]
            {
                0f,
                0.25f,
                0.25f,
                0.57f,
                0.86f,
                1f
            };
            _statusStripBlend.Factors = new[]
            {
                0.1f,
                0.6f,
                1f,
                0.4f,
                0f,
                0.95f
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemplateRenderer" /> class.
        /// </summary>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        public TemplateRenderer()
            : base(ColorTable)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Creates the arrow path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateArrowPath(ToolStripItem item, Rectangle rect, ArrowDirection direction)
        {
            var flag = direction == ArrowDirection.Left || direction == ArrowDirection.Right;
            var flag2 = flag;
            checked
            {
                int num;
                int num2;
                if (flag2)
                {
                    num = (int) Math.Round(Math.Round(unchecked(rect.Right - checked(rect.Width - 4)/2.0)));
                    num2 = (int) Math.Round(Math.Round(unchecked(rect.Y + rect.Height/2.0)));
                }
                else
                {
                    num = (int) Math.Round(Math.Round(unchecked(rect.X + rect.Width/2.0)));
                    num2 = (int) Math.Round(Math.Round(unchecked(rect.Bottom - checked(rect.Height - 3)/2.0)));
                    flag = (item is ToolStripDropDownButton && item.RightToLeft == RightToLeft.Yes);
                    flag2 = flag;
                    if (flag2)
                    {
                        num++;
                    }
                }
                var graphicsPath = new GraphicsPath();
                switch (direction)
                {
                    case ArrowDirection.Left:
                        graphicsPath.AddLine(num - 4, num2, num, num2 - 4);
                        graphicsPath.AddLine(num, num2 - 4, num, num2 + 4);
                        graphicsPath.AddLine(num, num2 + 4, num - 4, num2);
                        break;
                    case ArrowDirection.Up:
                        unchecked
                        {
                            graphicsPath.AddLine(num + 3f, num2, num - 3f, num2);
                            graphicsPath.AddLine(num - 3f, num2, num, num2 - 4f);
                            graphicsPath.AddLine(num, num2 - 4f, num + 3f, num2);
                            break;
                        }
                    case ArrowDirection.Right:
                        graphicsPath.AddLine(num, num2, num - 4, num2 - 4);
                        graphicsPath.AddLine(num - 4, num2 - 4, num - 4, num2 + 4);
                        graphicsPath.AddLine(num - 4, num2 + 4, num, num2);
                        break;
                    case ArrowDirection.Down:
                        unchecked
                        {
                            graphicsPath.AddLine(num + 3f, num2 - 3f, num - 2f, num2 - 3f);
                            graphicsPath.AddLine(num - 2f, num2 - 3f, num, num2);
                            graphicsPath.AddLine(num, num2, num + 3f, num2 - 3f);
                            break;
                        }
                }
                return graphicsPath;
            }
        }

        /// <summary>
        ///     Creates the border path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="exclude">The exclude.</param>
        /// <param name="cut">The cut.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            var flag = exclude.IsEmpty;
            var flag2 = flag;
            checked
            {
                GraphicsPath result;
                if (flag2)
                {
                    result = CreateBorderPath(rect, cut);
                }
                else
                {
                    rect.Width--;
                    rect.Height--;
                    var list = new List<PointF>();
                    var x = (float) rect.X;
                    var num = (float) rect.Y;
                    var x2 = (float) rect.Right;
                    var y = (float) rect.Bottom;
                    GraphicsPath graphicsPath;
                    int num7;
                    unchecked
                    {
                        var num2 = rect.X + cut;
                        var num3 = rect.Right - cut;
                        var y2 = rect.Y + cut;
                        var y3 = rect.Bottom - cut;
                        var num4 = (cut == 0f) ? 1f : cut;
                        flag = (rect.Y >= exclude.Top && rect.Y <= exclude.Bottom);
                        flag2 = flag;
                        PointF item;
                        if (flag2)
                        {
                            var num5 = checked(exclude.X - 1) - cut;
                            var num6 = exclude.Right + cut;
                            flag = (num2 <= num5);
                            flag2 = flag;
                            if (flag2)
                            {
                                var list2 = list;
                                item = new PointF(num2, num);
                                list2.Add(item);
                                var list3 = list;
                                item = new PointF(num5, num);
                                list3.Add(item);
                                var list4 = list;
                                item = new PointF(num5 + cut, num - num4);
                                list4.Add(item);
                            }
                            else
                            {
                                num5 = checked(exclude.X - 1);
                                var list5 = list;
                                item = new PointF(num5, num);
                                list5.Add(item);
                                var list6 = list;
                                item = new PointF(num5, num - num4);
                                list6.Add(item);
                            }
                            flag = (num3 > num6);
                            flag2 = flag;
                            if (flag2)
                            {
                                var list7 = list;
                                item = new PointF(num6 - cut, num - num4);
                                list7.Add(item);
                                var list8 = list;
                                item = new PointF(num6, num);
                                list8.Add(item);
                                var list9 = list;
                                item = new PointF(num3, num);
                                list9.Add(item);
                            }
                            else
                            {
                                num6 = exclude.Right;
                                var list10 = list;
                                item = new PointF(num6, num - num4);
                                list10.Add(item);
                                var list11 = list;
                                item = new PointF(num6, num);
                                list11.Add(item);
                            }
                        }
                        else
                        {
                            var list12 = list;
                            item = new PointF(num2, num);
                            list12.Add(item);
                            var list13 = list;
                            item = new PointF(num3, num);
                            list13.Add(item);
                        }
                        var list14 = list;
                        item = new PointF(x2, y2);
                        list14.Add(item);
                        var list15 = list;
                        item = new PointF(x2, y3);
                        list15.Add(item);
                        var list16 = list;
                        item = new PointF(num3, y);
                        list16.Add(item);
                        var list17 = list;
                        item = new PointF(num2, y);
                        list17.Add(item);
                        var list18 = list;
                        item = new PointF(x, y3);
                        list18.Add(item);
                        var list19 = list;
                        item = new PointF(x, y2);
                        list19.Add(item);
                        graphicsPath = new GraphicsPath();
                        num7 = 1;
                    }
                    var num8 = list.Count - 1;
                    var num9 = num7;
                    while (true)
                    {
                        var num10 = num9;
                        var num11 = num8;
                        flag2 = (num10 > num11);
                        if (flag2)
                        {
                            break;
                        }
                        graphicsPath.AddLine(list[num9 - 1], list[num9]);
                        num9++;
                    }
                    graphicsPath.AddLine(list[list.Count - 1], list[0]);
                    result = graphicsPath;
                }
                return result;
            }
        }

        /// <summary>
        ///     Creates the border path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cut">The cut.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateBorderPath(Rectangle rect, float cut)
        {
            GraphicsPath graphicsPath;
            checked
            {
                rect.Width--;
                rect.Height--;
                graphicsPath = new GraphicsPath();
            }
            graphicsPath.AddLine(rect.Left + cut, rect.Top, rect.Right - cut, rect.Top);
            graphicsPath.AddLine(rect.Right - cut, rect.Top, rect.Right, rect.Top + cut);
            graphicsPath.AddLine(rect.Right, rect.Top + cut, rect.Right, rect.Bottom - cut);
            graphicsPath.AddLine(rect.Right, rect.Bottom - cut, rect.Right - cut, rect.Bottom);
            graphicsPath.AddLine(rect.Right - cut, rect.Bottom, rect.Left + cut, rect.Bottom);
            graphicsPath.AddLine(rect.Left + cut, rect.Bottom, rect.Left, rect.Bottom - cut);
            graphicsPath.AddLine(rect.Left, rect.Bottom - cut, rect.Left, rect.Top + cut);
            graphicsPath.AddLine(rect.Left, rect.Top + cut, rect.Left + cut, rect.Top);
            return graphicsPath;
        }

        /// <summary>
        ///     Creates the clip border path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cut">The cut.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
        {
            checked
            {
                rect.Width++;
                rect.Height++;
                return CreateBorderPath(rect, cut);
            }
        }

        /// <summary>
        ///     Creates the clip border path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="exclude">The exclude.</param>
        /// <param name="cut">The cut.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateClipBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            checked
            {
                rect.Width++;
                rect.Height++;
                return CreateBorderPath(rect, exclude, cut);
            }
        }

        /// <summary>
        ///     Creates the indeterminate path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateIndeterminatePath(Rectangle rect)
        {
            checked
            {
                var num = (int) Math.Round(Math.Round(unchecked(rect.X + rect.Width/2.0)));
                var num2 = (int) Math.Round(Math.Round(unchecked(rect.Y + rect.Height/2.0)));
                var graphicsPath = new GraphicsPath();
                graphicsPath.AddLine(num - 3, num2, num, num2 - 3);
                graphicsPath.AddLine(num, num2 - 3, num + 3, num2);
                graphicsPath.AddLine(num + 3, num2, num, num2 + 3);
                graphicsPath.AddLine(num, num2 + 3, num - 3, num2);
                return graphicsPath;
            }
        }

        /// <summary>
        ///     Creates the inside border path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cut">The cut.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
        {
            rect.Inflate(-1, -1);
            return CreateBorderPath(rect, cut);
        }

        /// <summary>
        ///     Creates the inside border path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="exclude">The exclude.</param>
        /// <param name="cut">The cut.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateInsideBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            rect.Inflate(-1, -1);
            return CreateBorderPath(rect, exclude, cut);
        }

        /// <summary>
        ///     Creates the tick path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateTickPath(Rectangle rect)
        {
            checked
            {
                var num = (int) Math.Round(Math.Round(unchecked(rect.X + rect.Width/2.0)));
                var num2 = (int) Math.Round(Math.Round(unchecked(rect.Y + rect.Height/2.0)));
                var graphicsPath = new GraphicsPath();
                graphicsPath.AddLine(num - 4, num2, num - 2, num2 + 4);
                graphicsPath.AddLine(num - 2, num2 + 4, num + 3, num2 - 5);
                return graphicsPath;
            }
        }

        /// <summary>
        ///     Draws the arc.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="Radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath DrawArc(Rectangle Rectangle, int Radius = 4)
        {
            var graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180f, 90f);
            checked
            {
                graphicsPath.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270f, 90f);
                graphicsPath.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0f, 90f);
                graphicsPath.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90f, 90f);
                graphicsPath.CloseFigure();
                return graphicsPath;
            }
        }

        /// <summary>
        ///     Draws the context menu header.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="item">The item.</param>
        private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
        {
            var rect = new Rectangle(Point.Empty, item.Bounds.Size);
            var graphicsPath = CreateBorderPath(rect, _cutToolItemMenu);
            try
            {
                var graphicsPath2 = CreateInsideBorderPath(rect, _cutToolItemMenu);
                try
                {
                    var graphicsPath3 = CreateClipBorderPath(rect, _cutToolItemMenu);
                    try
                    {
                        var useClipping = new UseClipping(g, graphicsPath3);
                        try
                        {
                            var solidBrush = new SolidBrush(_separatorMenuLight);
                            try
                            {
                                g.FillPath(solidBrush, graphicsPath);
                            }
                            finally
                            {
                                var flag = solidBrush != null;
                                var flag2 = flag;
                                if (flag2)
                                {
                                    ((IDisposable) solidBrush).Dispose();
                                }
                            }
                            var pen = new Pen(ColorTable.MenuBorder);
                            try
                            {
                                g.DrawPath(pen, graphicsPath);
                            }
                            finally
                            {
                                var flag3 = pen != null;
                                var flag2 = flag3;
                                if (flag2)
                                {
                                    pen.Dispose();
                                }
                            }
                        }
                        finally
                        {
                            var flag4 = useClipping != null;
                            var flag2 = flag4;
                            if (flag2)
                            {
                                ((IDisposable) useClipping).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        var flag5 = graphicsPath3 != null;
                        var flag2 = flag5;
                        if (flag2)
                        {
                            graphicsPath3.Dispose();
                        }
                    }
                }
                finally
                {
                    var flag6 = graphicsPath2 != null;
                    var flag2 = flag6;
                    if (flag2)
                    {
                        graphicsPath2.Dispose();
                    }
                }
            }
            finally
            {
                var flag7 = graphicsPath != null;
                var flag2 = flag7;
                if (flag2)
                {
                    graphicsPath.Dispose();
                }
            }
        }

        /// <summary>
        ///     Draws the gradient back.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="backRect">The back rect.</param>
        /// <param name="colors">The colors.</param>
        private void DrawGradientBack(Graphics g, Rectangle backRect, GradientItemColors colors)
        {
            backRect.Inflate(-1, -1);
            checked
            {
                var num = (int) Math.Round(Math.Round(backRect.Height/2.0));
                var rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
                var rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
                var rect = rectangle;
                var rect2 = rectangle2;
                rect.Inflate(1, 1);
                rect2.Inflate(1, 1);
                var linearGradientBrush = new LinearGradientBrush(rect, colors.cInsideTop1, colors.cInsideTop2, 90f);
                try
                {
                    var linearGradientBrush2 = new LinearGradientBrush(rect2, colors.cInsideBottom1,
                        colors.cInsideBottom2, 90f);
                    try
                    {
                        g.FillRectangle(linearGradientBrush, rectangle);
                        g.FillRectangle(linearGradientBrush2, rectangle2);
                    }
                    finally
                    {
                        var flag = linearGradientBrush2 != null;
                        var flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable) linearGradientBrush2).Dispose();
                        }
                    }
                }
                finally
                {
                    var flag3 = linearGradientBrush != null;
                    var flag2 = flag3;
                    if (flag2)
                    {
                        ((IDisposable) linearGradientBrush).Dispose();
                    }
                }
                num = (int) Math.Round(Math.Round(backRect.Height/2.0));
                rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
                rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
                rect = rectangle;
                rect2 = rectangle2;
                rect.Inflate(1, 1);
                rect2.Inflate(1, 1);
                var linearGradientBrush3 = new LinearGradientBrush(rect, colors.cFillTop1, colors.cFillTop2, 90f);
                try
                {
                    var linearGradientBrush4 = new LinearGradientBrush(rect2, colors.cFillBottom1, colors.cFillBottom2,
                        90f);
                    try
                    {
                        backRect.Inflate(-1, -1);
                        num = (int) Math.Round(Math.Round(backRect.Height/2.0));
                        rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
                        rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
                        g.FillRectangle(linearGradientBrush3, rectangle);
                        g.FillRectangle(linearGradientBrush4, rectangle2);
                    }
                    finally
                    {
                        var flag4 = linearGradientBrush4 != null;
                        var flag2 = flag4;
                        if (flag2)
                        {
                            ((IDisposable) linearGradientBrush4).Dispose();
                        }
                    }
                }
                finally
                {
                    var flag5 = linearGradientBrush3 != null;
                    var flag2 = flag5;
                    if (flag2)
                    {
                        ((IDisposable) linearGradientBrush3).Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     Draws the gradient border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="backRect">The back rect.</param>
        /// <param name="colors">The colors.</param>
        private void DrawGradientBorder(Graphics g, Rectangle backRect, GradientItemColors colors)
        {
            var useAntiAlias = new UseAntiAlias(g);
            try
            {
                var rect = backRect;
                rect.Inflate(1, 1);
                var linearGradientBrush = new LinearGradientBrush(rect, colors.cBorder1, colors.cBorder2, 90f);
                try
                {
                    linearGradientBrush.SetSigmaBellShape(0.5f);
                    var pen = new Pen(linearGradientBrush);
                    try
                    {
                        var graphicsPath = CreateBorderPath(backRect, _cutMenuItemBack);
                        try
                        {
                            g.DrawPath(pen, graphicsPath);
                        }
                        finally
                        {
                            var flag = graphicsPath != null;
                            var flag2 = flag;
                            if (flag2)
                            {
                                graphicsPath.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        var flag3 = pen != null;
                        var flag2 = flag3;
                        if (flag2)
                        {
                            pen.Dispose();
                        }
                    }
                }
                finally
                {
                    var flag4 = linearGradientBrush != null;
                    var flag2 = flag4;
                    if (flag2)
                    {
                        ((IDisposable) linearGradientBrush).Dispose();
                    }
                }
            }
            finally
            {
                var flag5 = useAntiAlias != null;
                var flag2 = flag5;
                if (flag2)
                {
                    ((IDisposable) useAntiAlias).Dispose();
                }
            }
        }

        /// <summary>
        ///     Draws the gradient context menu item.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="item">The item.</param>
        /// <param name="colors">The colors.</param>
        private void DrawGradientContextMenuItem(Graphics g, ToolStripItem item, GradientItemColors colors)
        {
            var backRect = new Rectangle(2, 0, checked(item.Bounds.Width - 3), item.Bounds.Height);
            DrawGradientItem(g, backRect, colors);
        }

        /// <summary>
        ///     Draws the gradient item.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="backRect">The back rect.</param>
        /// <param name="colors">The colors.</param>
        private void DrawGradientItem(Graphics g, Rectangle backRect, GradientItemColors colors)
        {
            var flag = backRect.Width > 0 && backRect.Height > 0;
            var flag2 = flag;
            if (flag2)
            {
                DrawGradientBack(g, backRect, colors);
                DrawGradientBorder(g, backRect, colors);
            }
        }

        /// <summary>
        ///     Draws the gradient tool item.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="item">The item.</param>
        /// <param name="colors">The colors.</param>
        private void DrawGradientToolItem(Graphics g, ToolStripItem item, GradientItemColors colors)
        {
            var backRect = new Rectangle(Point.Empty, item.Bounds.Size);
            DrawGradientItem(g, backRect, colors);
        }

        /// <summary>
        ///     Draws the gradient tool split item.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="splitButton">The split button.</param>
        /// <param name="colorsButton">The colors button.</param>
        /// <param name="colorsDrop">The colors drop.</param>
        /// <param name="colorsSplit">The colors split.</param>
        private void DrawGradientToolSplitItem(Graphics g, ToolStripSplitButton splitButton,
            GradientItemColors colorsButton, GradientItemColors colorsDrop, GradientItemColors colorsSplit)
        {
            var empty = Point.Empty;
            var bounds = splitButton.Bounds;
            var rectangle = new Rectangle(empty, bounds.Size);
            var dropDownButtonBounds = splitButton.DropDownButtonBounds;
            var flag = rectangle.Width > 0 && dropDownButtonBounds.Width > 0 && rectangle.Height > 0 &&
                        dropDownButtonBounds.Height > 0;
            var flag2 = flag;
            checked
            {
                if (flag2)
                {
                    var backRect = rectangle;
                    flag = (dropDownButtonBounds.X > 0);
                    flag2 = flag;
                    int num;
                    if (flag2)
                    {
                        backRect.Width = dropDownButtonBounds.Left;
                        dropDownButtonBounds.X--;
                        dropDownButtonBounds.Width++;
                        num = dropDownButtonBounds.X;
                    }
                    else
                    {
                        backRect.Width -= dropDownButtonBounds.Width - 2;
                        backRect.X = dropDownButtonBounds.Right - 1;
                        dropDownButtonBounds.Width++;
                        num = dropDownButtonBounds.Right - 1;
                    }
                    var graphicsPath = CreateBorderPath(rectangle, _cutMenuItemBack);
                    try
                    {
                        DrawGradientBack(g, backRect, colorsButton);
                        DrawGradientBack(g, dropDownButtonBounds, colorsDrop);
                        bounds = new Rectangle(rectangle.X + num, rectangle.Top, 1, rectangle.Height + 1);
                        var linearGradientBrush = new LinearGradientBrush(bounds, colorsSplit.cBorder1,
                            colorsSplit.cBorder2, 90f);
                        try
                        {
                            linearGradientBrush.SetSigmaBellShape(0.5f);
                            var pen = new Pen(linearGradientBrush);
                            try
                            {
                                g.DrawLine(pen, rectangle.X + num, rectangle.Top + 1, rectangle.X + num,
                                    rectangle.Bottom - 1);
                            }
                            finally
                            {
                                flag = (pen != null);
                                flag2 = flag;
                                if (flag2)
                                {
                                    pen.Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag = (linearGradientBrush != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable) linearGradientBrush).Dispose();
                            }
                        }
                        DrawGradientBorder(g, rectangle, colorsButton);
                    }
                    finally
                    {
                        flag = (graphicsPath != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            graphicsPath.Dispose();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Draws the grip glyph.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="darkBrush">The dark brush.</param>
        /// <param name="lightBrush">The light brush.</param>
        private void DrawGripGlyph(Graphics g, int x, int y, Brush darkBrush, Brush lightBrush)
        {
            checked
            {
                g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare);
                g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderArrow" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripArrowRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var flag = e.ArrowRectangle.Width > 0 && e.ArrowRectangle.Height > 0;
            var flag2 = flag;
            if (flag2)
            {
                var graphicsPath = CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction);
                try
                {
                    var bounds = graphicsPath.GetBounds();
                    bounds.Inflate(1f, 1f);
                    var color = e.Item.Enabled ? _arrowLight : _arrowDisabled;
                    var color2 = e.Item.Enabled ? _arrowDark : _arrowDisabled;
                    flag = e.Item.Selected;
                    flag2 = flag;
                    if (flag2)
                    {
                        color = _arrowSelected;
                        color2 = _arrowSelected;
                    }
                    var angle = 0f;
                    switch (e.Direction)
                    {
                        case ArrowDirection.Left:
                            angle = 180f;
                            break;
                        case ArrowDirection.Up:
                            angle = 270f;
                            break;
                        case ArrowDirection.Right:
                            angle = 0f;
                            break;
                        case ArrowDirection.Down:
                            angle = 90f;
                            break;
                    }
                    var linearGradientBrush = new LinearGradientBrush(bounds, color, color2, angle);
                    try
                    {
                        e.Graphics.FillPath(linearGradientBrush, graphicsPath);
                    }
                    finally
                    {
                        flag = (linearGradientBrush != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable) linearGradientBrush).Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (graphicsPath != null);
                    flag2 = flag;
                    if (flag2)
                    {
                        graphicsPath.Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var toolStripButton = (ToolStripButton) e.Item;
            var flag = !toolStripButton.Selected && !toolStripButton.Pressed;
            bool flag2;
            bool flag3;
            if (flag)
            {
                flag2 = !toolStripButton.Checked;
                if (flag2)
                {
                    flag3 = false;
                    goto IL_3D;
                }
            }
            flag3 = true;
            IL_3D:
            var flag4 = flag3;
            flag2 = flag4;
            if (flag2)
            {
                RenderToolButtonBackground(e.Graphics, toolStripButton, e.ToolStrip);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderDropDownButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var flag = e.Item.Selected || e.Item.Pressed;
            var flag2 = flag;
            if (flag2)
            {
                RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderImageMargin" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            var flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
            var flag2 = flag;
            checked
            {
                if (flag2)
                {
                    var affectedBounds = e.AffectedBounds;
                    var flag3 = e.ToolStrip.RightToLeft == RightToLeft.Yes;
                    affectedBounds.Y += _marginInset;
                    affectedBounds.Height -= _marginInset*2;
                    flag = !flag3;
                    flag2 = flag;
                    if (flag2)
                    {
                        affectedBounds.X += _marginInset;
                    }
                    else
                    {
                        affectedBounds.X = (int) Math.Round(Math.Round(unchecked(affectedBounds.X + _marginInset/2.0)));
                    }
                    var solidBrush = new SolidBrush(ColorTable.ImageMarginGradientBegin);
                    try
                    {
                        e.Graphics.FillRectangle(solidBrush, affectedBounds);
                    }
                    finally
                    {
                        flag = (solidBrush != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable) solidBrush).Dispose();
                        }
                    }
                    var pen = new Pen(_separatorMenuLight);
                    try
                    {
                        var pen2 = new Pen(_separatorMenuDark);
                        try
                        {
                            flag = !flag3;
                            flag2 = flag;
                            if (flag2)
                            {
                                e.Graphics.DrawLine(pen, affectedBounds.Right, affectedBounds.Top, affectedBounds.Right,
                                    affectedBounds.Bottom);
                                e.Graphics.DrawLine(pen2, affectedBounds.Right - 1, affectedBounds.Top,
                                    affectedBounds.Right - 1, affectedBounds.Bottom);
                            }
                            else
                            {
                                e.Graphics.DrawLine(pen, affectedBounds.Left - 1, affectedBounds.Top,
                                    affectedBounds.Left - 1, affectedBounds.Bottom);
                                e.Graphics.DrawLine(pen2, affectedBounds.Left, affectedBounds.Top, affectedBounds.Left,
                                    affectedBounds.Bottom);
                            }
                        }
                        finally
                        {
                            flag = (pen2 != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                pen2.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag = (pen != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            pen.Dispose();
                        }
                    }
                }
                else
                {
                    base.OnRenderImageMargin(e);
                }
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderItemCheck" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemImageRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            var imageRectangle = e.ImageRectangle;
            imageRectangle.Inflate(1, 1);
            var flag = imageRectangle.Top > _checkInset;
            var flag2 = flag;
            checked
            {
                if (flag2)
                {
                    var num = imageRectangle.Top - _checkInset;
                    imageRectangle.Y -= num;
                    imageRectangle.Height += num;
                }
                flag = (imageRectangle.Height <= e.Item.Bounds.Height - _checkInset*2);
                flag2 = flag;
                if (flag2)
                {
                    var num2 = e.Item.Bounds.Height - _checkInset*2 - imageRectangle.Height;
                    imageRectangle.Height += num2;
                }
                var useAntiAlias = new UseAntiAlias(e.Graphics);
                try
                {
                    var graphicsPath = CreateBorderPath(imageRectangle, _cutMenuItemBack);
                    try
                    {
                        var solidBrush = new SolidBrush(ColorTable.CheckBackground);
                        try
                        {
                            e.Graphics.FillPath(solidBrush, graphicsPath);
                        }
                        finally
                        {
                            flag = (solidBrush != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable) solidBrush).Dispose();
                            }
                        }
                        var pen = new Pen(e.Item.Selected ? _contextCheckBorderSelected : _contextCheckBorder);
                        try
                        {
                            e.Graphics.DrawPath(pen, graphicsPath);
                        }
                        finally
                        {
                            flag = (pen != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                pen.Dispose();
                            }
                        }
                        flag = (e.Image != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            var checkState = CheckState.Unchecked;
                            flag = (e.Item is ToolStripMenuItem);
                            flag2 = flag;
                            if (flag2)
                            {
                                var toolStripMenuItem = (ToolStripMenuItem) e.Item;
                                checkState = toolStripMenuItem.CheckState;
                            }
                            switch (checkState)
                            {
                                case CheckState.Checked:
                                    flag2 = true;
                                    if (flag2)
                                    {
                                        var graphicsPath2 = CreateTickPath(imageRectangle);
                                        try
                                        {
                                            var pen2 =
                                                new Pen(
                                                    e.Item.Selected ? _contextCheckTickSelected : _contextCheckTick,
                                                    _contextCheckTickThickness);
                                            try
                                            {
                                                e.Graphics.DrawPath(pen2, graphicsPath2);
                                            }
                                            finally
                                            {
                                                flag = (pen2 != null);
                                                flag2 = flag;
                                                if (flag2)
                                                {
                                                    pen2.Dispose();
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            flag = (graphicsPath2 != null);
                                            flag2 = flag;
                                            if (flag2)
                                            {
                                                graphicsPath2.Dispose();
                                            }
                                        }
                                    }
                                    break;
                                case CheckState.Indeterminate:
                                    flag2 = true;
                                    if (flag2)
                                    {
                                        var graphicsPath3 = CreateIndeterminatePath(imageRectangle);
                                        try
                                        {
                                            var solidBrush2 =
                                                new SolidBrush(e.Item.Selected
                                                    ? _contextCheckTickSelected
                                                    : _contextCheckTick);
                                            try
                                            {
                                                e.Graphics.FillPath(solidBrush2, graphicsPath3);
                                            }
                                            finally
                                            {
                                                flag = (solidBrush2 != null);
                                                flag2 = flag;
                                                if (flag2)
                                                {
                                                    ((IDisposable) solidBrush2).Dispose();
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            flag = (graphicsPath3 != null);
                                            flag2 = flag;
                                            if (flag2)
                                            {
                                                graphicsPath3.Dispose();
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    finally
                    {
                        flag = (graphicsPath != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            graphicsPath.Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (useAntiAlias != null);
                    flag2 = flag;
                    if (flag2)
                    {
                        ((IDisposable) useAntiAlias).Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderItemImage" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemImageRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            var flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
            var flag2 = flag;
            if (flag2)
            {
                var flag3 = e.Image != null;
                flag2 = flag3;
                if (flag2)
                {
                    var enabled = e.Item.Enabled;
                    flag2 = enabled;
                    if (flag2)
                    {
                        e.Graphics.DrawImage(e.Image, e.ImageRectangle);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y,
                            Color.Transparent);
                    }
                }
            }
            else
            {
                base.OnRenderItemImage(e);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderItemText" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemTextRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = forecolor;
            base.OnRenderItemText(e);
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderMenuItemBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var flag = !(e.ToolStrip is MenuStrip) && !(e.ToolStrip is ContextMenuStrip);
            bool flag2;
            bool flag3;
            if (flag)
            {
                flag2 = !(e.ToolStrip is ToolStripDropDownMenu);
                if (flag2)
                {
                    flag3 = false;
                    goto IL_45;
                }
            }
            flag3 = true;
            IL_45:
            var flag4 = flag3;
            flag2 = flag4;
            if (flag2)
            {
                var flag5 = e.Item.Pressed && e.ToolStrip is MenuStrip;
                flag2 = flag5;
                if (flag2)
                {
                    DrawContextMenuHeader(e.Graphics, e.Item);
                }
                else
                {
                    flag5 = e.Item.Selected;
                    flag2 = flag5;
                    if (flag2)
                    {
                        flag4 = e.Item.Enabled;
                        flag2 = flag4;
                        if (flag2)
                        {
                            var flag6 = e.ToolStrip is MenuStrip;
                            flag2 = flag6;
                            if (flag2)
                            {
                                DrawGradientToolItem(e.Graphics, e.Item, _itemToolItemSelectedColors);
                            }
                            else
                            {
                                DrawGradientContextMenuItem(e.Graphics, e.Item, _itemContextItemEnabledColors);
                            }
                        }
                        else
                        {
                            var pt = e.ToolStrip.PointToClient(Control.MousePosition);
                            var flag7 = !e.Item.Bounds.Contains(pt);
                            flag2 = flag7;
                            if (flag2)
                            {
                                flag5 = (e.ToolStrip is MenuStrip);
                                flag2 = flag5;
                                if (flag2)
                                {
                                    DrawGradientToolItem(e.Graphics, e.Item, _itemDisabledColors);
                                }
                                else
                                {
                                    DrawGradientContextMenuItem(e.Graphics, e.Item, _itemDisabledColors);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderSplitButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var flag = e.Item.Selected || e.Item.Pressed;
            var flag2 = flag;
            if (flag2)
            {
                var toolStripSplitButton = (ToolStripSplitButton) e.Item;
                RenderToolSplitButtonBackground(e.Graphics, toolStripSplitButton, e.ToolStrip);
                var dropDownButtonBounds = toolStripSplitButton.DropDownButtonBounds;
                OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics, toolStripSplitButton, dropDownButtonBounds,
                    SystemColors.ControlText, ArrowDirection.Down));
            }
            else
            {
                base.OnRenderSplitButtonBackground(e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderStatusStripSizingGrip" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            var solidBrush = new SolidBrush(_gripDark);
            checked
            {
                try
                {
                    var solidBrush2 = new SolidBrush(_gripLight);
                    try
                    {
                        var flag = e.ToolStrip.RightToLeft == RightToLeft.Yes;
                        var num = e.AffectedBounds.Bottom - _gripSize*2 + 1;
                        var num2 = _gripLines;
                        while (true)
                        {
                            var num3 = num2;
                            var num4 = 1;
                            var flag2 = num3 < num4;
                            if (flag2)
                            {
                                break;
                            }
                            var num5 = flag ? (e.AffectedBounds.Left + 1) : (e.AffectedBounds.Right - _gripSize*2 + 1);
                            var num6 = 0;
                            var num7 = num2 - 1;
                            var num8 = num6;
                            while (true)
                            {
                                var num9 = num8;
                                num4 = num7;
                                flag2 = (num9 > num4);
                                if (flag2)
                                {
                                    break;
                                }
                                DrawGripGlyph(e.Graphics, num5, num, solidBrush, solidBrush2);
                                num5 -= (flag ? (0 - _gripMove) : _gripMove);
                                num8++;
                            }
                            num -= _gripMove;
                            num2 += -1;
                        }
                    }
                    finally
                    {
                        var flag3 = solidBrush2 != null;
                        var flag2 = flag3;
                        if (flag2)
                        {
                            ((IDisposable) solidBrush2).Dispose();
                        }
                    }
                }
                finally
                {
                    var flag4 = solidBrush != null;
                    var flag2 = flag4;
                    if (flag2)
                    {
                        ((IDisposable) solidBrush).Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderToolStripBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)), e.AffectedBounds);
            //return;

            var flag = e.ToolStrip is StatusStrip;
            if (!flag)
            {
                var flag2 = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
                flag = flag2;
                if (flag)
                {
                    var graphicsPath = CreateBorderPath(e.AffectedBounds, _cutContextMenu);
                    try
                    {
                        var graphicsPath2 = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu);
                        try
                        {
                            var useClipping = new UseClipping(e.Graphics, graphicsPath2);
                            try
                            {
                                var solidBrush = new SolidBrush(_contextMenuBack);
                                try
                                {
                                    e.Graphics.FillPath(solidBrush, graphicsPath);
                                }
                                finally
                                {
                                    flag2 = (solidBrush != null);
                                    flag = flag2;
                                    if (flag)
                                    {
                                        ((IDisposable) solidBrush).Dispose();
                                    }
                                }
                            }
                            finally
                            {
                                flag2 = (useClipping != null);
                                flag = flag2;
                                if (flag)
                                {
                                    ((IDisposable) useClipping).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag2 = (graphicsPath2 != null);
                            flag = flag2;
                            if (flag)
                            {
                                graphicsPath2.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag2 = (graphicsPath != null);
                        flag = flag2;
                        if (flag)
                        {
                            graphicsPath.Dispose();
                        }
                    }
                }
                else
                {
                    flag2 = (e.ToolStrip is StatusStrip);
                    flag = flag2;
                    if (flag)
                    {
                        var rect = new RectangleF(0f, 1.5f, (float) e.ToolStrip.Width,
                            (float) checked(e.ToolStrip.Height - 2));
                        flag2 = (rect.Width > 0f && rect.Height > 0f);
                        flag = flag2;
                        if (flag)
                        {
                            var linearGradientBrush = new LinearGradientBrush(rect, ColorTable.StatusStripGradientBegin,
                                ColorTable.StatusStripGradientEnd, 90f);
                            try
                            {
                                linearGradientBrush.Blend = _statusStripBlend;
                                e.Graphics.FillRectangle(linearGradientBrush, rect);
                            }
                            finally
                            {
                                flag2 = (linearGradientBrush != null);
                                flag = flag2;
                                if (flag)
                                {
                                    ((IDisposable) linearGradientBrush).Dispose();
                                }
                            }
                        }
                    }
                    else
                    {
                        base.OnRenderToolStripBackground(e);
                    }
                }
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RenderToolStripBorder" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            /*bool flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
            bool flag2 = flag;
            checked
            {
                if (flag2)
                {
                    bool flag3 = !e.ConnectedArea.IsEmpty;
                    flag2 = flag3;
                    if (flag2)
                    {
                        SolidBrush solidBrush = new SolidBrush(TemplateRenderer._contextMenuBack);
                        try
                        {
                            e.Graphics.FillRectangle(solidBrush, e.ConnectedArea);
                        }
                        finally
                        {
                            flag3 = (solidBrush != null);
                            flag2 = flag3;
                            if (flag2)
                            {
                                ((IDisposable)solidBrush).Dispose();
                            }
                        }
                    }
                    GraphicsPath graphicsPath = this.CreateBorderPath(e.AffectedBounds, e.ConnectedArea, TemplateRenderer._cutContextMenu);
                    try
                    {
                        GraphicsPath graphicsPath2 = this.CreateInsideBorderPath(e.AffectedBounds, e.ConnectedArea, TemplateRenderer._cutContextMenu);
                        try
                        {
                            GraphicsPath graphicsPath3 = this.CreateClipBorderPath(e.AffectedBounds, e.ConnectedArea, TemplateRenderer._cutContextMenu);
                            try
                            {
                                Pen pen = new Pen(TemplateRenderer.ColorTable.MenuBorder);
                                try
                                {
                                    Pen pen2 = new Pen(TemplateRenderer._separatorMenuLight);
                                    try
                                    {
                                        UseClipping useClipping = new UseClipping(e.Graphics, graphicsPath3);
                                        try
                                        {
                                            UseAntiAlias useAntiAlias = new UseAntiAlias(e.Graphics);
                                            try
                                            {
                                                e.Graphics.DrawPath(pen2, graphicsPath2);
                                                e.Graphics.DrawPath(pen, graphicsPath);
                                            }
                                            finally
                                            {
                                                flag3 = (useAntiAlias != null);
                                                flag2 = flag3;
                                                if (flag2)
                                                {
                                                    ((IDisposable)useAntiAlias).Dispose();
                                                }
                                            }
                                            e.Graphics.DrawLine(pen, e.AffectedBounds.Right, e.AffectedBounds.Bottom, e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom - 1);
                                        }
                                        finally
                                        {
                                            flag3 = (useClipping != null);
                                            flag2 = flag3;
                                            if (flag2)
                                            {
                                                ((IDisposable)useClipping).Dispose();
                                            }
                                        }
                                    }
                                    finally
                                    {
                                        flag3 = (pen2 != null);
                                        flag2 = flag3;
                                        if (flag2)
                                        {
                                            ((IDisposable)pen2).Dispose();
                                        }
                                    }
                                }
                                finally
                                {
                                    flag3 = (pen != null);
                                    flag2 = flag3;
                                    if (flag2)
                                    {
                                        ((IDisposable)pen).Dispose();
                                    }
                                }
                            }
                            finally
                            {
                                flag3 = (graphicsPath3 != null);
                                flag2 = flag3;
                                if (flag2)
                                {
                                    ((IDisposable)graphicsPath3).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag3 = (graphicsPath2 != null);
                            flag2 = flag3;
                            if (flag2)
                            {
                                ((IDisposable)graphicsPath2).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag3 = (graphicsPath != null);
                        flag2 = flag3;
                        if (flag2)
                        {
                            ((IDisposable)graphicsPath).Dispose();
                        }
                    }
                }
                else
                {
                    bool flag4 = e.ToolStrip is StatusStrip;
                    flag2 = flag4;
                    if (flag2)
                    {
                        Pen pen3 = new Pen(TemplateRenderer._statusStripBorderDark);
                        try
                        {
                            Pen pen4 = new Pen(TemplateRenderer._statusStripBorderLight);
                            try
                            {
                                e.Graphics.DrawLine(pen3, 0, 0, e.ToolStrip.Width, 0);
                                e.Graphics.DrawLine(pen4, 0, 1, e.ToolStrip.Width, 1);
                            }
                            finally
                            {
                                flag4 = (pen4 != null);
                                flag2 = flag4;
                                if (flag2)
                                {
                                    ((IDisposable)pen4).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag4 = (pen3 != null);
                            flag2 = flag4;
                            if (flag2)
                            {
                                ((IDisposable)pen3).Dispose();
                            }
                        }
                    }
                    else
                    {
                        base.OnRenderToolStripBorder(e);
                    }
                }
            }*/
        }

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripContentPanelBackground" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.ToolStripContentPanelRenderEventArgs" /> that contains the event
        ///     data.
        /// </param>
        protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            base.OnRenderToolStripContentPanelBackground(e);
            var flag = e.ToolStripContentPanel.Width > 0 && e.ToolStripContentPanel.Height > 0;
            var flag2 = flag;
            if (flag2)
            {
                var linearGradientBrush = new LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle,
                    ColorTable.ToolStripContentPanelGradientEnd, ColorTable.ToolStripContentPanelGradientBegin, 90f);
                try
                {
                    e.Graphics.FillRectangle(linearGradientBrush, e.ToolStripContentPanel.ClientRectangle);
                }
                finally
                {
                    flag = (linearGradientBrush != null);
                    flag2 = flag;
                    if (flag2)
                    {
                        ((IDisposable) linearGradientBrush).Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     Renders the tool button background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="button">The button.</param>
        /// <param name="toolstrip">The toolstrip.</param>
        private void RenderToolButtonBackground(Graphics g, ToolStripButton button, ToolStrip toolstrip)
        {
            var enabled = button.Enabled;
            var flag = enabled;
            if (flag)
            {
                var @checked = button.Checked;
                flag = @checked;
                if (flag)
                {
                    var flag2 = button.Pressed;
                    flag = flag2;
                    if (flag)
                    {
                        DrawGradientToolItem(g, button, _itemToolItemPressedColors);
                    }
                    else
                    {
                        flag2 = button.Selected;
                        flag = flag2;
                        if (flag)
                        {
                            DrawGradientToolItem(g, button, _itemToolItemCheckPressColors);
                        }
                        else
                        {
                            DrawGradientToolItem(g, button, _itemToolItemCheckedColors);
                        }
                    }
                }
                else
                {
                    var flag3 = button.Pressed;
                    flag = flag3;
                    if (flag)
                    {
                        DrawGradientToolItem(g, button, _itemToolItemPressedColors);
                    }
                    else
                    {
                        flag3 = button.Selected;
                        flag = flag3;
                        if (flag)
                        {
                            DrawGradientToolItem(g, button, _itemToolItemSelectedColors);
                        }
                    }
                }
            }
            else
            {
                var flag4 = button.Selected;
                flag = flag4;
                if (flag)
                {
                    var pt = toolstrip.PointToClient(Control.MousePosition);
                    flag4 = !button.Bounds.Contains(pt);
                    flag = flag4;
                    if (flag)
                    {
                        DrawGradientToolItem(g, button, _itemDisabledColors);
                    }
                }
            }
        }

        /// <summary>
        ///     Renders the tool drop button background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="item">The item.</param>
        /// <param name="toolstrip">The toolstrip.</param>
        private void RenderToolDropButtonBackground(Graphics g, ToolStripItem item, ToolStrip toolstrip)
        {
            var flag = item.Selected || item.Pressed;
            var flag2 = flag;
            if (flag2)
            {
                var enabled = item.Enabled;
                flag2 = enabled;
                if (flag2)
                {
                    var pressed = item.Pressed;
                    flag2 = pressed;
                    if (flag2)
                    {
                        DrawContextMenuHeader(g, item);
                    }
                    else
                    {
                        DrawGradientToolItem(g, item, _itemToolItemSelectedColors);
                    }
                }
                else
                {
                    var pt = toolstrip.PointToClient(Control.MousePosition);
                    var flag3 = !item.Bounds.Contains(pt);
                    flag2 = flag3;
                    if (flag2)
                    {
                        DrawGradientToolItem(g, item, _itemDisabledColors);
                    }
                }
            }
        }

        /// <summary>
        ///     Renders the tool split button background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="splitButton">The split button.</param>
        /// <param name="toolstrip">The toolstrip.</param>
        private void RenderToolSplitButtonBackground(Graphics g, ToolStripSplitButton splitButton, ToolStrip toolstrip)
        {
            var flag = splitButton.Selected || splitButton.Pressed;
            var flag2 = flag;
            if (flag2)
            {
                var enabled = splitButton.Enabled;
                flag2 = enabled;
                if (flag2)
                {
                    var flag3 = !splitButton.Pressed && splitButton.ButtonPressed;
                    flag2 = flag3;
                    if (flag2)
                    {
                        DrawGradientToolSplitItem(g, splitButton, _itemToolItemPressedColors,
                            _itemToolItemSelectedColors, _itemContextItemEnabledColors);
                    }
                    else
                    {
                        flag3 = (splitButton.Pressed && !splitButton.ButtonPressed);
                        flag2 = flag3;
                        if (flag2)
                        {
                            DrawContextMenuHeader(g, splitButton);
                        }
                        else
                        {
                            DrawGradientToolSplitItem(g, splitButton, _itemToolItemSelectedColors,
                                _itemToolItemSelectedColors, _itemContextItemEnabledColors);
                        }
                    }
                }
                else
                {
                    var pt = toolstrip.PointToClient(Control.MousePosition);
                    var flag4 = !splitButton.Bounds.Contains(pt);
                    flag2 = flag4;
                    if (flag2)
                    {
                        DrawGradientToolItem(g, splitButton, _itemDisabledColors);
                    }
                }
            }
        }

        #endregion Methods
    }
}