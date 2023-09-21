using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Generic repository interface for managing entities of type T.
    /// </summary>
    /// <typeparam name="T">The type representing an entity.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID, if found; otherwise, null.</returns>
        T GetById(int id);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>All entities.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Finds entities based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the entities.</param>
        /// <returns>A list of entities that match the specified criteria.</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Adds a range of entities.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Removes a range of entities.
        /// </summary>
        /// <param name="entities">The entities to remove.</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);
    }
}