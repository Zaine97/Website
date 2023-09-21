using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    /// <summary>
    /// Interface for managing products.
    /// </summary>
    /// <typeparam name="Product">The type representing a product.</typeparam>
    public interface IProductsRepository<Product> where Product : class
    {
        Task<List<Product>> GetAllAsync();
        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, if found; otherwise, null.</returns>
        Product GetById(int id);

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>All products.</returns>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Finds products based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the products.</param>
        /// <returns>A list of products that match the specified criteria.</returns>
        IEnumerable<Product> Find(Expression<Func<Product, bool>> expression);

        /// <summary>
        /// Adds a product.
        /// </summary>
        /// <param name="entity">The product to add.</param>
        void Add(Product entity);

        /// <summary>
        /// Adds a range of products.
        /// </summary>
        /// <param name="entities">The products to add.</param>
        void AddRange(IEnumerable<Product> entities);

        /// <summary>
        /// Removes a product.
        /// </summary>
        /// <param name="entity">The product to remove.</param>
        void Remove(Product entity);

        /// <summary>
        /// Removes a range of products.
        /// </summary>
        /// <param name="entities">The products to remove.</param>
        void RemoveRange(IEnumerable<Product> entities);

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="entity">The product to update.</param>
        void Update(Product entity);
    }
}