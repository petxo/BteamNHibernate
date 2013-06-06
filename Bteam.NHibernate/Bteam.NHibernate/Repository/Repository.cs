namespace Bteam.NHibernate.Repository
{
    public abstract class Repository<TEntity, TId> : RepositoryReadOnly<TEntity, TId>, IRepository<TEntity, TId> 
                                                    where TEntity : class, IIdentificableEntity<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="nHibernateHelper">The n hibernate helper.</param>
        protected Repository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Save(TEntity entity)
        {
            NHibernateHelper.CurrentSession.SaveOrUpdate(entity);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            NHibernateHelper.CurrentSession.Save(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            NHibernateHelper.CurrentSession.Update(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            NHibernateHelper.CurrentSession.Delete(entity);   
        }

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public virtual void Flush()
        {
            NHibernateHelper.CurrentSession.Flush();
        }
    }
}