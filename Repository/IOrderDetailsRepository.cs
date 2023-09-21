using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Interface for managing order details.
    /// </summary>
    /// <typeparam name="OrderDetails">The type representing order details.</typeparam>
    public interface IOrderDetailsRepository<OrderDetails> where OrderDetails : class
    {
        /// <summary>
        /// Gets order details by their ID.
        /// </summary>
        OrderDetails GetById(int id);

        /// <summary>
        /// Gets all order details.
        /// </summary>
        IEnumerable<OrderDetails> GetAll();

        /// <summary>
        /// Finds order details based on the specified criteria.
        /// </summary>
        IEnumerable<OrderDetails> Find(Expression<Func<OrderDetails, bool>> expression);

        /// <summary>
        /// Adds order details.
        /// </summary>
        void Add(OrderDetails entity);

        /// <summary>
        /// Adds a range of order details.
        /// </summary>
        void AddRange(IEnumerable<OrderDetails> entities);

        /// <summary>
        /// Removes order details.
        /// </summary>
        void Remove(OrderDetails entity);

        /// <summary>
        /// Removes a range of order details.
        /// </summary>
        void RemoveRange(IEnumerable<OrderDetails> entities);

        /// <summary>
        /// Updates order details.
        /// </summary>
        void Update(OrderDetails entity);
    }
}