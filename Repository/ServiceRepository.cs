using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Repository for managing services.
    /// </summary>
    /// <typeparam name="Service">The type representing a service.</typeparam>
    public class ServiceRepository<Service> : IServiceRepository<Service> where Service : class
    {
        private readonly DbContext _context;
        private readonly DbSet<Service> _serviceDbSet;

        /// <summary>
        /// Constructor for ServiceRepository.
        /// </summary>
        /// <param name="context">The DbContext.</param>
        public ServiceRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _serviceDbSet = context.Set<Service>();
        }

        /// <summary>
        /// Asynchronously gets all services.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains the list of services.</returns>
        public async Task<List<Service>> GetAllAsync()
        {
            return await _serviceDbSet.ToListAsync();
        }

        /// <summary>
        /// Gets a service by its ID.
        /// </summary>
        /// <param name="id">The ID of the service to retrieve.</param>
        /// <returns>The service with the specified ID, if found; otherwise, null.</returns>
        public Service GetById(int id)
        {
            return _serviceDbSet.Find(id);
        }

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns>All services.</returns>
        public IEnumerable<Service> GetAll()
        {
            return _serviceDbSet.ToList();
        }

        /// <summary>
        /// Finds services based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the services.</param>
        /// <returns>A list of services that match the specified criteria.</returns>
        public IEnumerable<Service> Find(Expression<Func<Service, bool>> expression)
        {
            return _serviceDbSet.Where(expression).ToList();
        }

        /// <summary>
        /// Adds a service.
        /// </summary>
        /// <param name="entity">The service to add.</param>
        public void Add(Service entity)
        {
            if (entity != null)
            {
                _serviceDbSet.Add(entity);
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
        }

        /// <summary>
        /// Adds a range of services.
        /// </summary>
        /// <param name="entities">The services to add.</param>
        public void AddRange(IEnumerable<Service> entities)
        {
            if (entities != null && entities.Any())
            {
                _serviceDbSet.AddRange(entities);
            }
        }

        /// <summary>
        /// Removes a service.
        /// </summary>
        /// <param name="entity">The service to remove.</param>
        public void Remove(Service entity)
        {
            if (entity != null)
            {
                _serviceDbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Removes a range of services.
        /// </summary>
        /// <param name="entities">The services to remove.</param>
        public void RemoveRange(IEnumerable<Service> entities)
        {
            if (entities != null && entities.Any())
            {
                _serviceDbSet.RemoveRange(entities);
            }
        }

        /// <summary>
        /// Updates a service.
        /// </summary>
        /// <param name="entity">The service to update.</param>
        public void Update(Service entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}