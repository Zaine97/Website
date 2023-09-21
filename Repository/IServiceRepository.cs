using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Generic interface for managing services.
    /// </summary>
    /// <typeparam name="Service">The type representing a service.</typeparam>
    public interface IServiceRepository<Service> where Service : class
    {
        /// <summary>
        /// Asynchronously gets all services.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains the list of services.</returns>
        Task<List<Service>> GetAllAsync();

        /// <summary>
        /// Gets a service by its ID.
        /// </summary>
        /// <param name="id">The ID of the service to retrieve.</param>
        /// <returns>The service with the specified ID, if found; otherwise, null.</returns>
        Service GetById(int id);

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns>All services.</returns>
        IEnumerable<Service> GetAll();

        /// <summary>
        /// Finds services based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the services.</param>
        /// <returns>A list of services that match the specified criteria.</returns>
        IEnumerable<Service> Find(Expression<Func<Service, bool>> expression);

        /// <summary>
        /// Adds a service.
        /// </summary>
        /// <param name="entity">The service to add.</param>
        void Add(Service entity);

        /// <summary>
        /// Adds a range of services.
        /// </summary>
        /// <param name="entities">The services to add.</param>
        void AddRange(IEnumerable<Service> entities);

        /// <summary>
        /// Removes a service.
        /// </summary>
        /// <param name="entity">The service to remove.</param>
        void Remove(Service entity);

        /// <summary>
        /// Removes a range of services.
        /// </summary>
        /// <param name="entities">The services to remove.</param>
        void RemoveRange(IEnumerable<Service> entities);

        /// <summary>
        /// Updates a service.
        /// </summary>
        /// <param name="entity">The service to update.</param>
        void Update(Service entity);
    }

}