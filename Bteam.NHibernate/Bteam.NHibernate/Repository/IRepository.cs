namespace Bteam.NHibernate.Repository
{
    public interface IRepository<TEntity, in TId> : IRepositoryReadOnly<TEntity, TId> where TEntity : IIdentificableEntity<TId>
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(TEntity entity);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        void Flush();
    }
}