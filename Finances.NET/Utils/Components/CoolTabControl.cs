#region

using System;
using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils.Components
{
    /// <summary>
    ///     Class CoolTabControl.
    /// </summary>
    public class CoolTabControl : TabControl
    {
        #region Methods

        /// <summary>
        ///     This member overrides <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />.
        /// </summary>
        /// <param name="m">A Windows Message Object.</param>
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr) 1;
            else base.WndProc(ref m);
        }

        #endregion Methods of CoolTabControl (1)
    }
}