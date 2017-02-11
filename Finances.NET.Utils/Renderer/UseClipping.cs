#region

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace Finances.NET.Utils.Renderer
{
    /// <summary>
    ///     Class UseClipping.
    /// </summary>
    /// <remarks>Admir Cosic, 08-03-2014</remarks>
    internal class UseClipping : IDisposable
    {
        #region Fields

        /// <summary>
        ///     The _g
        /// </summary>
        private readonly Graphics _g;

        /// <summary>
        ///     The _old
        /// </summary>
        private readonly Region _old;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UseClipping" /> class.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="path">The path.</param>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        public UseClipping(Graphics g, GraphicsPath path)
        {
            _g = g;
            _old = g.Clip;
            var region = _old.Clone();
            region.Intersect(path);
            _g.Clip = region;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UseClipping" /> class.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="region">The region.</param>
        /// <remarks>Admir Cosic, 08-03-2014</remarks>
        public UseClipping(Graphics g, Region region)
        {
            _g = g;
            _old = g.Clip;
            var region2 = _old.Clone();
            region2.Intersect(region);
            _g.Clip = region2;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _g.Clip = _old;
        }

        #endregion Methods
    }
}