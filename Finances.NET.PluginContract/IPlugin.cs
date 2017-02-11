using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.NET.PluginContract
{
    /// <summary>
    /// Interface IPlugin
    /// </summary>
    public interface IPlugin : IPluginMetaData
    {
        /// <summary>
        /// Executes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="language">The language.</param>
        void Execute(object obj, string language="");
        /// <summary>
        /// Executes this instance.
        /// </summary>
        void Execute();
    }
}
