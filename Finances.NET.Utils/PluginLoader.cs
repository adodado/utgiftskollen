using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Finances.NET.PluginContract;

namespace Finances.NET.Utils
{
    /// <summary>
    /// Class PluginLoader.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PluginLoader
    {
        /// <summary>
        /// The _ container
        /// </summary>
		private CompositionContainer _Container;

        /// <summary>
        /// Gets or sets the plugins.
        /// </summary>
        /// <value>The plugins.</value>
		[ImportMany]
		public IEnumerable<IPlugin> Plugins
		{
			get;
			set;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginLoader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
		public PluginLoader(string path)
		{
			var directoryCatalog = new DirectoryCatalog(path);
            var catalog = new AggregateCatalog(directoryCatalog);
            _Container = new CompositionContainer(catalog);
            _Container.ComposeParts(this);
		}
    }
}
