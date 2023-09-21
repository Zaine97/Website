using EcoPower_Logistics.Repository;  // Assuming this is the namespace where ICustomersRepository<Customer> is defined
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

/// <summary>
/// Repository for managing customers.
/// </summary>
/// <typeparam name="Customer">The type representing a customer.</typeparam>
public class CustomersRepository<Customer> : ICustomersRepository<Customer> where Customer : class
{
    private readonly DbContext _context;
    private readonly DbSet<Customer> _customerDbSet;

    public CustomersRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _customerDbSet = context.Set<Customer>();
    }

    /// <summary>
    /// Gets a customer by their ID.
    /// </summary>
    public Customer GetById(int id)
    {
        return _customerDbSet.Find(id);
    }

    /// <summary>
    /// Gets all customers.
    /// </summary>
    public IEnumerable<Customer> GetAll()
    {
        return _customerDbSet.ToList();
    }

    /// <summary>
    /// Finds customers based on the specified criteria.
    /// </summary>
    public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> expression)
    {
        return _customerDbSet.Where(expression).ToList();
    }

    /// <summary>
    /// Adds a customer.
    /// </summary>
    public void Add(Customer entity)
    {
        _customerDbSet.Add(entity);
    }

    /// <summary>
    /// Adds a range of customers.
    /// </summary>
    public void AddRange(IEnumerable<Customer> entities)
    {
        _customerDbSet.AddRange(entities);
    }

    /// <summary>
    /// Removes a customer.
    /// </summary>
    public void Remove(Customer entity)
    {
        if (entity != null)
        {
            _customerDbSet.Remove(entity);
        }
    }

    /// <summary>
    /// Removes a range of customers.
    /// </summary>
    public void RemoveRange(IEnumerable<Customer> entities)
    {
        if (entities != null && entities.Any())
        {
            _customerDbSet.RemoveRange(entities);
        }
    }

    /// <summary>
    /// Updates a customer.
    /// </summary>
    public void Update(Customer entity)
    {
        if (entity != null)
        {
            _customerDbSet.Update(entity);
        }
    }
}