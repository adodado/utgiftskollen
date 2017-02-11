#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#endregion

namespace Finances.NET.Utils.Components
{
    /// <summary>
    ///     Class DoubleBufferListView.
    /// </summary>
    public class DoubleBufferListView : ListView
    {
        #region Properties

        /// <summary>
        ///     This property is not relevant for this class.
        /// </summary>
        /// <value>The create parameters.</value>
        /// <returns>null in all cases.</returns>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DoubleBufferListView" /> class.
        /// </summary>
        public DoubleBufferListView()
        {
            SetWindowTheme(Handle, "Explorer", null);
            DoubleBuffered = true;
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw,
                true);

            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Handles the <see cref="E:HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(Handle, "Explorer", null);
        }

        /// <summary>
        ///     Notifies the control of Windows messages.
        /// </summary>
        /// <param name="m">A <see cref="T:System.Windows.Forms.Message" /> that represents the Windows message.</param>
        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        /// <summary>
        ///     Sets the window theme.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pszSubAppName">Name of the PSZ sub application.</param>
        /// <param name="pszSubIdList">The PSZ sub identifier list.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        #endregion Methods
    }
}