using Microsoft.EntityFrameworkCore;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly LogisticsShipmentDbContext _context;
    protected readonly DbSet<T> _dbSet;
    public GenericRepository(LogisticsShipmentDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IReadOnlyCollection<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyCollection<T>> GetPage(int take, int skip)
    {
        return await _dbSet.Take(take).Skip(skip).ToListAsync();
    }

    public IQueryable<T> Query()
    {
        return _dbSet;
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
