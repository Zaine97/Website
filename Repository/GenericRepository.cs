using EcoPower_Logistics.Repository;  // Assuming this is the namespace where IGenericRepository<T> is defined
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

/// <summary>
/// Generic repository for managing entities of type T.
/// </summary>
/// <typeparam name="T">The type representing an entity.</typeparam>
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    /// <summary>
    /// Finds entities based on the specified criteria.
    /// </summary>
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).ToList();
    }

    /// <summary>
    /// Adds an entity.
    /// </summary>
    public void Add(T entity)
    {
        if (entity != null)
        {
            _dbSet.Add(entity);
        }
        else
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }
    }

    /// <summary>
    /// Adds a range of entities.
    /// </summary>
    public void AddRange(IEnumerable<T> entities)
    {
        if (entities != null && entities.Any())
        {
            _dbSet.AddRange(entities);
        }
    }

    /// <summary>
    /// Removes an entity.
    /// </summary>
    public void Remove(T entity)
    {
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    /// <summary>
    /// Removes a range of entities.
    /// </summary>
    public void RemoveRange(IEnumerable<T> entities)
    {
        if (entities != null && entities.Any())
        {
            _dbSet.RemoveRange(entities);
        }
    }

    /// <summary>
    /// Updates an entity.
    /// </summary>
    public void Update(T entity)
    {
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}