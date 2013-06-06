using System;
using System.Collections.Generic;

namespace Bteam.NHibernate.Repository
{
    public abstract class RepositoryReadOnly<TEntity, TId> : IRepositoryReadOnly<TEntity, TId> 
                                                            where TEntity : class, IIdentificableEntity<TId>
    {
        private readonly INHibernateHelper _nHibernateHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryReadOnly&lt;TEntity, TId&gt;"/> class.
        /// </summary>
        /// <param name="nHibernateHelper">The n hibernate helper.</param>
        protected RepositoryReadOnly(INHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        /// <summary>
        /// Gets the N hibernate helper.
        /// </summary>
        /// <value>The N hibernate helper.</value>
        protected INHibernateHelper NHibernateHelper
        {
            get { return _nHibernateHelper; }
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual TEntity Get(TId id)
        {
            return NHibernateHelper.CurrentSession.Get<TEntity>(id);
        }

        /// <summary>
        /// Loads the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual TEntity Load(TId id)
        {
            return NHibernateHelper.CurrentSession.Load<TEntity>(id);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> FindAll()
        {
            return NHibernateHelper.CurrentSession.CreateCriteria<TEntity>()
                .List<TEntity>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                NHibernateHelper.Dispose();
            }
        }
    }
}