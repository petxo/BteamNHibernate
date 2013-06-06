using System.Configuration;

namespace Bteam.NHibernate.Config
{
    public class NHibernateHelperConfig : ConfigurationSection
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
        /// Gets the sessions.
        /// </summary>
        /// <value>The sessions.</value>
        [ConfigurationProperty("sessions", IsRequired = true)]
        public NHibernateSessionListConfig Sessions
        {
            get
            {
                return (NHibernateSessionListConfig)this["sessions"] ?? new NHibernateSessionListConfig();
            }
        }

    }
}