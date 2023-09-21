using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class ProductsRepository<Product> : IProductsRepository<Product> where Product : class
    {
        public async Task<List<Product>> GetAllAsync()
        {
            return await _productDbSet.ToListAsync();
        }
        private readonly DbContext _context;
        private readonly DbSet<Product> _productDbSet;

        public ProductsRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _productDbSet = context.Set<Product>();
        }

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, if found; otherwise, null.</returns>
        public Product GetById(int id)
        {
            return _productDbSet.Find(id);
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>All products.</returns>
        public IEnumerable<Product> GetAll()
        {
            return _productDbSet.ToList();
        }

        /// <summary>
        /// Finds products based on the specified criteria.
        /// </summary>
        /// <param name="expression">The criteria to filter the products.</param>
        /// <returns>A list of products that match the specified criteria.</returns>
        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return _productDbSet.Where(expression).ToList();
        }

        /// <summary>
        /// Adds a product.
        /// </summary>
        /// <param name="entity">The product to add.</param>
        public void Add(Product entity)
        {
            if (entity != null)
            {
                _productDbSet.Add(entity);
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
        }

        /// <summary>
        /// Adds a range of products.
        /// </summary>
        /// <param name="entities">The products to add.</param>
        public void AddRange(IEnumerable<Product> entities)
        {
            if (entities != null && entities.Any())
            {
                _productDbSet.AddRange(entities);
            }
        }

        /// <summary>
        /// Removes a product.
        /// </summary>
        /// <param name="entity">The product to remove.</param>
        public void Remove(Product entity)
        {
            if (entity != null)
            {
                _productDbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Removes a range of products.
        /// </summary>
        /// <param name="entities">The products to remove.</param>
        public void RemoveRange(IEnumerable<Product> entities)
        {
            if (entities != null && entities.Any())
            {
                _productDbSet.RemoveRange(entities);
            }
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="entity">The product to update.</param>
        public void Update(Product entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}