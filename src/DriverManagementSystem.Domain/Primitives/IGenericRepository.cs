namespace DriverManagementSystem.Domain.Primitives;

public interface IGenericRepository<TEntity, TId> where TEntity : BaseEntitiy<TId>
{
    Task<List<TEntity>> GetAllAsync(Func<string> func);
    Task<TEntity> GetByIdAsync(Func<string> func, TId id);
    Task<TId> AddAsync(Func<string> func, TEntity driver);
    Task UpdateAsync(Func<string> func, TEntity driver);
    Task DeleteAsync(Func<string> func, TId id);
}
