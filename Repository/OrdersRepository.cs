using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Repository for managing orders.
    /// </summary>
    /// <typeparam name="Order">The type representing an order.</typeparam>
    public class OrdersRepository<Order> : IOdersRepository<Order> where Order : class
    {
        private readonly DbContext _context;
        private readonly DbSet<Order> _orderDbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> instance.</param>
        public OrdersRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _orderDbSet = context.Set<Order>();
        }

        /// <summary>
        /// Gets an order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>The order with the specified ID, if found; otherwise, null.</returns>
        public Order GetById(int id)
        {
            return _orderDbSet.Find(id);
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>All orders.</returns>
        public IEnumerable<Order> GetAll()
        {
            return _orderDbSet.ToList();
        }

        /// <summary>
        /// Finds orders based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the orders.</param>
        /// <returns>A list of orders that match the specified criteria.</returns>
        public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
        {
            return _orderDbSet.Where(expression).ToList();
        }

        /// <summary>
        /// Adds an order.
        /// </summary>
        /// <param name="entity">The order to add.</param>
        public void Add(Order entity)
        {
            if (entity != null)
            {
                _orderDbSet.Add(entity);
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
        }

        /// <summary>
        /// Adds a range of orders.
        /// </summary>
        /// <param name="entities">The orders to add.</param>
        public void AddRange(IEnumerable<Order> entities)
        {
            if (entities != null && entities.Any())
            {
                _orderDbSet.AddRange(entities);
            }
        }

        /// <summary>
        /// Removes an order.
        /// </summary>
        /// <param name="entity">The order to remove.</param>
        public void Remove(Order entity)
        {
            if (entity != null)
            {
                _orderDbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Removes a range of orders.
        /// </summary>
        /// <param name="entities">The orders to remove.</param>
        public void RemoveRange(IEnumerable<Order> entities)
        {
            if (entities != null && entities.Any())
            {
                _orderDbSet.RemoveRange(entities);
            }
        }

        /// <summary>
        /// Updates an order.
        /// </summary>
        /// <param name="entity">The order to update.</param>
        public void Update(Order entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}