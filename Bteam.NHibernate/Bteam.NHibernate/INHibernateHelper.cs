using System;
using NHibernate;

namespace Bteam.NHibernate
{
    public interface INHibernateHelper : IDisposable
    {
        /// <summary>
        /// Gets the current session.
        /// </summary>
        /// <value>The current session.</value>
        ISession CurrentSession { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="NHibernateHelper"/> is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        bool Disposed { get; }
    }
}