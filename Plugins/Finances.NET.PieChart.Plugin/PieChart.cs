using System.Collections.Generic;
using Finances.NET.Core.Accounts;
using Finances.NET.PluginContract;
using System;
using System.ComponentModel.Composition;

namespace Finances.NET.Pie.Plugin
{
    //TODO! Refactor more, break out everything possible. Also use resource file for string resources.

    /// <summary>
    /// Class PieChart.
    /// </summary>
    [Export(typeof(IPlugin))]
    public class PieChart : IPlugin
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
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; set; }

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
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PluginType Type { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public Dictionary<string, string> Name { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChart" /> class.
        /// </summary>
        public PieChart()
        {
            Name = new Dictionary<string, string>
            {
                {"en-US", "Piechart"},
                {"de-DE", "Kreisdiagramm"},
                {"sv-SE", "Cirkeldiagram"}
            };

            _autoStart = false;
            Id = new Guid("D5D1F76B-34CF-40E1-A978-1A819C122D82");
            Comments = "Insert comments here.";
            Version = "v1.0.0.0";
            Manufacturer = "Admir Cosic";
            Type = PluginType.Chart;
        }

        /// <summary>
        /// Executes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="language">The language.</param>
        public void Execute(object obj, string language)
        {
            new FrmPieChart((Account)obj, language).ShowDialog();
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
