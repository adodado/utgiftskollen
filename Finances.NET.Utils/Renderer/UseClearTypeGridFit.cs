#region

using System;
using System.Drawing;
using System.Drawing.Text;

#endregion

namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class UseClearTypeGridFit.
    /// </summary>
    /// <remarks>Admir Cosic, 08-03-2014</remarks>
    internal class UseClearTypeGridFit : IDisposable
    {
        #region Fields

        /// <summary>
        ///     The _g
        /// </summary>
        private readonly Graphics _g;

        /// <summary>
        ///     The _old
        /// </summary>
        private readonly TextRenderingHint _old;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UseClearTypeGridFit" /> class.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        public UseClearTypeGridFit(Graphics g)
        {
            _g = g;
            _old = _g.TextRenderingHint;
            _g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _g.TextRenderingHint = _old;
        }

        #endregion Methods
    }
}