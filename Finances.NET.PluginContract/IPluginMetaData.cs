using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.NET.PluginContract
{
    /// <summary>
    /// Interface IPluginMetaData
    /// </summary>
    public interface IPluginMetaData
    {
        /// <summary>
        /// Gets a value indicating whether [automatic start].
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
        bool AutoStart { get; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        Guid Id { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        Dictionary<string, string> Name { get; }
        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>The comments.</value>
        string Comments { get; }
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        string Version { get; }
        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        string Manufacturer { get; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        PluginType Type { get; }
    }
}
