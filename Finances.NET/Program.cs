#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Finances.NET.PluginContract;
using Finances.NET.Properties;
using Finances.NET.Utils;
using Finances.NET.Core.Currencies;

#endregion

namespace Finances.NET
{
    /// <summary>
    ///     Class Program.
    /// </summary>
    internal static class Program
    {
        #region Fields
        /// <summary>
        /// The plugins
        /// </summary>
       public static Dictionary<Guid, IPlugin> Plugins;

        /// <summary>
        ///     The types
        /// </summary>
        public static List<string> Types;

        #endregion Fields

        #region Methods

        /// <summary>
        ///     Event handler. Called by Default for property changed events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Property changed event information.</param>
        private static void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
            Thread.CurrentThread.CurrentCulture = Settings.Default.Lang;
            Thread.CurrentThread.CurrentUICulture = Settings.Default.Lang;
            Currency.Init(Settings.Default.Lang);
        }

        /// <summary>
        ///     Main entry-point for this application.
        /// </summary>
        /// <param name="args">Array of command-line argument strings.</param>
        [STAThread]
        private static void Main(string[] args)
        {
            Currency.Init(Settings.Default.Lang);
            Settings.Default.PropertyChanged += Default_PropertyChanged;

            Thread.CurrentThread.CurrentCulture = Settings.Default.Lang;
            Thread.CurrentThread.CurrentUICulture = Settings.Default.Lang;

            LoadPlugins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
 
            
            Application.Run(!args.Any()
                ? new MainWindow()
                : (args[0] == "" ? new MainWindow() : new MainWindow(args[0])));
        }

        /// <summary>
        /// Loads plugins found in the plugins folder.
        /// </summary>
        private static void LoadPlugins()
        {
            try
            {
                var loader = new PluginLoader("plugins");
                Plugins = new Dictionary<Guid, IPlugin>();
                var plugins = loader.Plugins;
                foreach (var item in plugins)
                {
                    Plugins.Add(item.Id, item);
                    if (item.AutoStart)
                        item.Execute();
                }

            }
            catch (Exception)
            {
                //TODO LOGGING!!!
                throw;
            }
        }

        #endregion Methods
    }
}