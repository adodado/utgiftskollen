#region

using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils.Components
{
    /// <summary>
    ///     Class NoBorderToolStrip.
    /// </summary>
    public class NoBorderToolStrip : ToolStrip
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoBorderToolStrip" /> class.
        /// </summary>
        public NoBorderToolStrip()
        {
            Renderer.RenderToolStripBorder += Renderer_RenderToolStripBorder;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        /// <summary>
        ///     Handles the RenderToolStripBorder event of the Renderer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ToolStripRenderEventArgs" /> instance containing the event data.</param>
        private void Renderer_RenderToolStripBorder(object sender, ToolStripRenderEventArgs e)
        {
        }

        #endregion Methods
    }
}