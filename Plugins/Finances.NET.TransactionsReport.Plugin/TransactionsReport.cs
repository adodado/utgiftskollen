using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.NET.Core.Accounts;
using Finances.NET.PluginContract;

namespace Finances.NET.TransactionsReport.Plugin
{
    //TODO! Refactor more, break out everything possible. Also use resource file for string resources.

    /// <summary>
    /// Class TransactionsReport.
    /// </summary>
    [Export(typeof(IPlugin))]
    public class TransactionsReport : IPlugin
    {
        /// <summary>
        /// The _id
        /// </summary>
        private readonly Guid _id;
        /// <summary>
        /// The _comments
        /// </summary>
        private readonly string _comments;
        /// <summary>
        /// The _version
        /// </summary>
        private readonly string _version;
        /// <summary>
        /// The _manufacturer
        /// </summary>
        private readonly string _manufacturer;
        /// <summary>
        /// The _type
        /// </summary>
        private PluginType _type;
        /// <summary>
        /// The _name
        /// </summary>
        private Dictionary<string, string> _name;

        /// <summary>
        /// The _auto start property.
        /// </summary>
        private bool _autoStart;

        /// <summary>
        /// Gets a value indicating whether [automatic start].
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
        public bool AutoStart
        {
            get { return _autoStart; }
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public Dictionary<string, string> Name { get { return _name; } }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments
        {
            get { return _comments; }
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version
        {
            get { return _version; }
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer
        {
            get { return _manufacturer; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public PluginType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsReport" /> class.
        /// </summary>
        public TransactionsReport()
        {
            _name = new Dictionary<string, string>
            {
                {"en-US", "Transactions"},
                {"de-DE", "Transaktionen"},
                {"sv-SE", "Transaktioner"}
            };

            _autoStart = false;
            _id = new Guid("{F5C5CF25-5328-4750-8881-FB06436DC455}");
            _comments = "Comments";
            _version = "v1.0.0.0";
            _manufacturer = "Admir Cosic";
            _type = PluginType.Report;
        }

        /// <summary>
        /// Executes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="language">The language.</param>
        public void Execute(object obj, string language = "")
        {
            new FrmTransactionsReport((Account)obj).ShowDialog();
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
