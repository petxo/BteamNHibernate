namespace Bteam.NHibernate
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId">The type of the id.</typeparam>
    public interface IIdentificableEntity<TId>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        TId Id { get; set; }
    }
}