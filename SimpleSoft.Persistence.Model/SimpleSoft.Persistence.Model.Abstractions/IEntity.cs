namespace SimpleSoft.Persistence.Model
{
    /// <summary>
    /// Represents an entity with an unique identifier
    /// </summary>
    /// <typeparam name="TId">The unique identifier type</typeparam>
    public interface IEntity<TId> : IEntity
    {
        /// <summary>
        /// The entity unique identifier
        /// </summary>
        TId Id { get; set; }
    }

    /// <summary>
    /// Represents an entity
    /// </summary>
    public interface IEntity
    {

    }
}
