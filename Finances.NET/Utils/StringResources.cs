using System;
using System.Globalization;
using System.Resources;
using Finances.NET.Properties;

namespace Finances.NET.Utils
{
    /// <summary>
    /// Class StringResources.
    /// </summary>
    public class StringResources
    {
        /// <summary>
        /// The _culture
        /// </summary>
        private CultureInfo _culture;
        /// <summary>
        /// The _manager
        /// </summary>
        private readonly ResourceManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringResources"/> class.
        /// </summary>
        public StringResources()
        {
            _manager= new ResourceManager("Finances.NET.Resources.Language.StringResource", typeof(MainWindow).Assembly);
            _culture = Settings.Default.Lang;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string GetString(string name)
        {
            return _manager.GetString(name, _culture);
        }

        /// <summary>
        /// Switches the language.
        /// </summary>
        public void SwitchLanguage()
        {
            if (Settings.Default.Lang.Equals(_culture)) return;

            _culture = Settings.Default.Lang;
        }

    }
}
