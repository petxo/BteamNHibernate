using System.Configuration;

namespace Bteam.NHibernate.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class NHibernateSessionConfig : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the file configuration path.
        /// </summary>
        /// <value>The file configuration path.</value>
        [ConfigurationProperty("fileConfigurationPath", IsRequired = true)]
        public string FileConfigurationPath
        {
            get
            {
                return (string)this["fileConfigurationPath"];
            }
            set
            {
                this["fileConfigurationPath"] = value;
            }
        }
    }
}