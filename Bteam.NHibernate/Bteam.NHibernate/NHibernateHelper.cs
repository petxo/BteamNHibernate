using Bteam.NHibernate.Config;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using NHibernate.Cfg;

namespace Bteam.NHibernate
{
    /// <summary>
    /// NHibernate Helper class
    /// </summary>
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly ILog _logger;
        private bool _disposed;

        private const string SectionName = "nhibernate";
        private static readonly IDictionary<string, ISessionFactory> SessionFactories;

        /// <summary>
        /// Initializes the <see cref="NHibernateHelper"/> class.
        /// </summary>
        static NHibernateHelper()
        {
            SessionFactories = new Dictionary<string, ISessionFactory>();

            var nHibernateHelperConfig = (NHibernateHelperConfig)
                                         System.Configuration.ConfigurationManager.GetSection(SectionName);

            foreach (NHibernateSessionConfig session in nHibernateHelperConfig.Sessions)
            {
                var configuration = new Configuration();
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, session.FileConfigurationPath);
                configuration.Configure(filePath);

                SessionFactories.Add(session.Name, configuration.BuildSessionFactory());
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateHelper"/> class.
        /// </summary>
        public NHibernateHelper(string factoryName)
            : this(factoryName, LogManager.GetLogger(typeof(NHibernateHelper)))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateHelper"/> class.
        /// </summary>
        /// <param name="factoryName">Name of the factory.</param>
        /// <param name="logger">The logger.</param>
        public NHibernateHelper(string factoryName, ILog logger)
            : this(factoryName, FlushMode.Auto, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateHelper"/> class.
        /// </summary>
        /// <param name="factoryName">Name of the factory.</param>
        /// <param name="flushMode">The flush mode.</param>
        /// <param name="logger">The logger.</param>
        public NHibernateHelper(string factoryName, FlushMode flushMode, ILog logger)
        {
            try
            {
                _disposed = false;
                _logger = logger;
                CurrentSession = SessionFactories[factoryName].OpenSession();
                CurrentSession.FlushMode = flushMode;
            }
            catch (Exception ex)
            {
                _logger.Error("Error Hibernate Helper", ex);
                throw;
            }
        }


        #endregion

        #region Properties
        /// <summary>
        /// Gets the current session.
        /// </summary>
        /// <value>The current session.</value>
        public ISession CurrentSession
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="NHibernateHelper"/> is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        public bool Disposed
        {
            get { return _disposed; }
        }

        #endregion

        #region .: IDisposable :.
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="NHibernateHelper"/> is reclaimed by garbage collection.
        /// </summary>
        ~NHibernateHelper()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && CurrentSession != null)
            {
                if (CurrentSession.IsOpen)
                {
                    CurrentSession.Close();
                }
                CurrentSession.Dispose();
                _disposed = true;
            }
        }

        #endregion .: IDisposable :.
    }
}