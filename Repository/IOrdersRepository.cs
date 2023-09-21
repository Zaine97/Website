using Models; // Assuming 'Models' is the namespace where the 'Order' class is defined
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Interface for managing orders.
    /// </summary>
    /// <typeparam name="Order">The type representing an order.</typeparam>
    public interface IOdersRepository<Order> where Order : class
    {
        /// <summary>
        /// Gets an order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>The order with the specified ID, if found; otherwise, null.</returns>
        Order GetById(int id);

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>All orders.</returns>
        IEnumerable<Order> GetAll();

        /// <summary>
        /// Finds orders based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the orders.</param>
        /// <returns>A list of orders that match the specified criteria.</returns>
        IEnumerable<Order> Find(Expression<Func<Order, bool>> expression);

        /// <summary>
        /// Adds an order.
        /// </summary>
        /// <param name="entity">The order to add.</param>
        void Add(Order entity);

        /// <summary>
        /// Adds a range of orders.
        /// </summary>
        /// <param name="entities">The orders to add.</param>
        void AddRange(IEnumerable<Order> entities);

        /// <summary>
        /// Removes an order.
        /// </summary>
        /// <param name="entity">The order to remove.</param>
        void Remove(Order entity);

        /// <summary>
        /// Removes a range of orders.
        /// </summary>
        /// <param name="entities">The orders to remove.</param>
        void RemoveRange(IEnumerable<Order> entities);

        /// <summary>
        /// Updates an order.
        /// </summary>
        /// <param name="entity">The order to update.</param>
        void Update(Order entity);
    }
}