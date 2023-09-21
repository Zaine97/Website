using EcoPower_Logistics.Repository;  // Assuming this is the namespace where IGenericRepository<T> is defined
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

/// <summary>
/// Repository for managing order details.
/// </summary>
/// <typeparam name="OrderDetails">The type representing order details.</typeparam>
public class OrderDetailsRepository<OrderDetails> : IOrderDetailsRepository<OrderDetails> where OrderDetails : class
{
    private readonly DbContext _context;
    private readonly DbSet<OrderDetails> _orderDetailsDbSet;

    public OrderDetailsRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _orderDetailsDbSet = context.Set<OrderDetails>();
    }

    /// <summary>
    /// Gets order details by their ID.
    /// </summary>
    public OrderDetails GetById(int id)
    {
        return _orderDetailsDbSet.Find(id);
    }

    /// <summary>
    /// Gets all order details.
    /// </summary>
    public IEnumerable<OrderDetails> GetAll()
    {
        return _orderDetailsDbSet.ToList();
    }

    /// <summary>
    /// Finds order details based on the specified criteria.
    /// </summary>
    public IEnumerable<OrderDetails> Find(Expression<Func<OrderDetails, bool>> expression)
    {
        return _orderDetailsDbSet.Where(expression).ToList();
    }

    /// <summary>
    /// Adds order details.
    /// </summary>
    public void Add(OrderDetails entity)
    {
        _orderDetailsDbSet.Add(entity);
    }

    /// <summary>
    /// Adds a range of order details.
    /// </summary>
    public void AddRange(IEnumerable<OrderDetails> entities)
    {
        _orderDetailsDbSet.AddRange(entities);
    }

    /// <summary>
    /// Removes order details.
    /// </summary>
    public void Remove(OrderDetails entity)
    {
        if (entity != null)
        {
            _orderDetailsDbSet.Remove(entity);
        }
    }

    /// <summary>
    /// Removes a range of order details.
    /// </summary>
    public void RemoveRange(IEnumerable<OrderDetails> entities)
    {
        if (entities != null && entities.Any())
        {
            _orderDetailsDbSet.RemoveRange(entities);
        }
    }

    /// <summary>
    /// Updates order details.
    /// </summary>
    public void Update(OrderDetails entity)
    {
        if (entity != null)
        {
            _orderDetailsDbSet.Update(entity);
        }
    }
}