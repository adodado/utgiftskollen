#region

using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils.UserControls
{
    /// <summary>
    ///     Animated progress control usercontrol.
    /// </summary>
    public partial class AnimatedProgressControl : UserControl
    {
        #region Fields

        /// <summary>
        ///     The _cancel
        /// </summary>
        private bool _cancel;

        /// <summary>
        ///     The _error
        /// </summary>
        private bool _error;

        /// <summary>
        ///     The _information
        /// </summary>
        private bool _information;

        /// <summary>
        ///     The _loading
        /// </summary>
        private bool _loading;

        /// <summary>
        ///     The _status text
        /// </summary>
        private string _statusText = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimatedProgressControl" /> class.
        /// </summary>
        public AnimatedProgressControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public properties

        /// <summary>
        ///     Gets or sets the status text.
        /// </summary>
        /// <value>The status text.</value>
        public string StatusText
        {
            get { return _statusText; }
            set
            {
                if (value != _statusText)
                {
                    _statusText = value;
                    progressLabel.Text = StatusText;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="AnimatedProgressControl" /> is loading.
        /// </summary>
        /// <value><c>true</c> if loading; otherwise, <c>false</c>.</value>
        public bool Loading
        {
            get { return _loading; }
            set
            {
                if (value != _loading)
                    _loading = value;

                if (value)
                {
                    Information = false;
                    Cancel = false;
                    Error = false;
                    pictureBox.Image = Properties.Resources.Animation;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="AnimatedProgressControl" /> is information.
        /// </summary>
        /// <value><c>true</c> if information; otherwise, <c>false</c>.</value>
        public bool Information
        {
            get { return _information; }
            set
            {
                if (value != _information)
                    _information = value;

                if (value)
                {
                    Loading = false;
                    Cancel = false;
                    Error = false;
                    pictureBox.Image = Properties.Resources.Information;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="AnimatedProgressControl" /> is cancel.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel
        {
            get { return _cancel; }
            set
            {
                if (value != _cancel)
                    _cancel = value;

                if (value)
                {
                    Loading = false;
                    Information = false;
                    Error = false;
                    pictureBox.Image = Properties.Resources.Warning;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="AnimatedProgressControl" /> is error.
        /// </summary>
        /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
        public bool Error
        {
            get { return _error; }
            set
            {
                if (value != _error)
                    _error = value;

                if (value)
                {
                    Loading = false;
                    Information = false;
                    Cancel = false;
                    pictureBox.Image = Properties.Resources.Error;
                }
            }
        }

        #endregion
    }
}