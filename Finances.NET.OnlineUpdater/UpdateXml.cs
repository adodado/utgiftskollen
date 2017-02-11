using System;
using System.Net;
using System.Xml;

namespace Finances.NET.OnlineUpdater
{
    public class UpdateXml
    {
        #region Members of UpdateXml

        private readonly string _description;
        private readonly string _filename;
        private readonly string _launchArguments;
        private readonly string _md5;
        private readonly Uri _uri;
        private readonly Version _version;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        internal string Description
        {
            get { return _description; }
        }
        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>The filename.</value>
        internal string Filename
        {
            get { return _filename; }
        }
        /// <summary>
        /// Gets the launch arguments.
        /// </summary>
        /// <value>The launch arguments.</value>
        internal string LaunchArguments
        {
            get { return _launchArguments; }
        }
        /// <summary>
        /// Gets the MD5.
        /// </summary>
        /// <value>The MD5.</value>
        internal string Md5
        {
            get { return _md5; }
        }
        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>The URI.</value>
        internal Uri Uri
        {
            get { return _uri; }
        }
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        internal Version Version
        {
            get { return _version; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateXml" /> class.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="md5">The MD5.</param>
        /// <param name="description">The description.</param>
        /// <param name="launchArguments">The launch arguments.</param>
        internal UpdateXml(Version version, Uri uri, string filename, string md5, string description,
                    string launchArguments)
        {
            _version = version;
            _uri = uri;
            _filename = filename;
            _md5 = md5;
            _description = description;
            _launchArguments = launchArguments;
        }

        #endregion

        #region Methods of UpdateXml

        /// <summary>
        /// Exists the on server.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool ExistsOnServer(Uri uri)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri.AbsoluteUri);
                var response = (HttpWebResponse)request.GetResponse();
                response.Close();

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                //TODO Logging!!
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is version greater] [the specified version].
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns><c>true</c> if [is version greater] [the specified version]; otherwise, <c>false</c>.</returns>
        internal bool IsVersionGreater(Version version)
        {
            return Version > version;
        }

        /// <summary>
        /// Parses the update XML.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="appId">The application identifier.</param>
        /// <returns>UpdateXml.</returns>
        internal static UpdateXml ParseUpdateXml(Uri uri, string appId)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(uri.AbsoluteUri);
                var node = doc.DocumentElement.SelectSingleNode("//update[@appID='" + appId + "']");

                if (node == null)
                    return null;

                var version = Version.Parse(node["latestVersion"].InnerText);
                var url = node["latestVersionUrl"].InnerText;
                var filename = node["fileName"].InnerText;
                var md5 = node["md5"].InnerText;
                var description = node["description"].InnerText;
                var launchArguments = node["launchArguments"].InnerText;

                return new UpdateXml(version, new Uri(url), filename, md5, description, launchArguments);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
