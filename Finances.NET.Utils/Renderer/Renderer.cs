#region

using System.Windows.Forms;

#endregion



namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class Renderer.
    /// </summary>
    public class Renderer
    {
        #region Fields

        /// <summary>
        ///     The colors
        /// </summary>
        public RenderParams Colors;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Renderer" /> class.
        /// </summary>
        public Renderer()
        {
            Colors = new RenderParams();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Gets the renderer.
        /// </summary>
        /// <returns>ToolStripRenderer.</returns>
        public ToolStripRenderer GetRenderer()
        {
            return new TemplateRenderer(Colors);
        }

        #endregion Methods
    }
}