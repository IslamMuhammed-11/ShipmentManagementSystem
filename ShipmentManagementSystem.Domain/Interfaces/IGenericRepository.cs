namespace ShipmentManagementSystem.Domain.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();

    Task<IReadOnlyCollection<TEntity>> GetPageAsync(int take, int skip);

    Task<TEntity?> GetByIdAsync(int id);

    IQueryable<TEntity> Query();

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
