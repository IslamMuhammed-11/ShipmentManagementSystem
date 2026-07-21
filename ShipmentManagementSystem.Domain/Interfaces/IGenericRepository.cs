namespace ShipmentManagementSystem.Domain.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<IReadOnlyCollection<TEntity>> GetAll();

    Task<IReadOnlyCollection<TEntity>> GetPage(int take, int skip);

    Task<TEntity?> GetById(int id);

    IQueryable<TEntity> Query();

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}
