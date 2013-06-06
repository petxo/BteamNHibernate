using System;
using System.Collections.Generic;

namespace Bteam.NHibernate.Repository
{
    public interface IRepositoryReadOnly<TEntity, in TId>: IDisposable where TEntity : IIdentificableEntity<TId>
    {
        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        TEntity Get(TId id);

        /// <summary>
        /// Loads the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        TEntity Load(TId id);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<TEntity> FindAll();
    }
}