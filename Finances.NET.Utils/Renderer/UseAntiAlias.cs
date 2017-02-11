#region

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class UseAntiAlias.
    /// </summary>
    /// <remarks>Admir Cosic, 08-03-2014</remarks>
    internal class UseAntiAlias : IDisposable
    {
        #region Fields

        /// <summary>
        ///     The _g
        /// </summary>
        private readonly Graphics _g;

        /// <summary>
        ///     The _old
        /// </summary>
        private readonly SmoothingMode _old;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UseAntiAlias" /> class.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        public UseAntiAlias(Graphics g)
        {
            _g = g;
            _old = _g.SmoothingMode;
            _g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _g.SmoothingMode = _old;
        }

        #endregion Methods
    }
}