#region

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Finances.NET.Core.Accounts;
using Finances.NET.PluginContract;

#endregion

namespace Finances.NET.LineChart.Plugin
{
    //TODO! Refactor more, break out everything possible. Also use resource file for string resources.

    /// <summary>
    /// Class LineChart.
    /// </summary>
    [Export(typeof (IPlugin))]
    public class LineChart : IPlugin
    {
        /// <summary>
        /// The _id
        /// </summary>
        private Guid _id;

        /// <summary>
        /// The _type
        /// </summary>
        private PluginType _type;

        /// <summary>
        /// The _auto start property.
        /// </summary>
        private bool _autoStart;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineChart" /> class.
        /// </summary>
        public LineChart()
        {
            Name=new Dictionary<string, string>
            {
                {"en-US", "Linechart"},
                {"de-DE", "Liniendiagramm"},
                {"sv-SE", "Linjediagram"}
            };

            _autoStart = false;
            Id = new Guid("CCFEB265-1C4B-457D-897C-E003ECB4D7C8");
            Comments = "Insert comments here.";
            Version = "v1.0.0.0";
            Manufacturer = "Admir Cosic";
            Type = PluginType.Chart;
        }

        /// <summary>
        /// Gets a value indicating whether [automatic start].
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
        public bool AutoStart
        {
            get { return _autoStart; }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public Dictionary<string, string> Name { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets the plugintype.
        /// </summary>
        /// <value>The plugintype.</value>
        public PluginType Type { get; set; }

        /// <summary>
        /// Executes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="language">The language.</param>
        public void Execute(object obj, string language)
        {
            new FrmLineChart((Account) obj, language).ShowDialog();
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}