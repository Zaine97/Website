using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Interface for managing customers.
    /// </summary>
    /// <typeparam name="Customer">The type representing a customer.</typeparam>
    public interface ICustomersRepository<Customer> where Customer : class
    {
        /// <summary>
        /// Gets a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer with the specified ID, if found; otherwise, null.</returns>
        Customer GetById(int id);

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>All customers.</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Finds customers based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the customers.</param>
        /// <returns>A list of customers that match the specified criteria.</returns>
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> expression);

        /// <summary>
        /// Adds a customer.
        /// </summary>
        /// <param name="entity">The customer to add.</param>
        void Add(Customer entity);

        /// <summary>
        /// Adds a range of customers.
        /// </summary>
        /// <param name="entities">The customers to add.</param>
        void AddRange(IEnumerable<Customer> entities);

        /// <summary>
        /// Removes a customer.
        /// </summary>
        /// <param name="entity">The customer to remove.</param>
        void Remove(Customer entity);

        /// <summary>
        /// Removes a range of customers.
        /// </summary>
        /// <param name="entities">The customers to remove.</param>
        void RemoveRange(IEnumerable<Customer> entities);

        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <param name="entity">The customer to update.</param>
        void Update(Customer entity);
    }
}