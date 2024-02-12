using Dapper;
using DriverManagementSystem.Domain.Primitives;
using System.Data;

namespace DriverManagementSystem.Infrastructure.Repositories;

public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : BaseEntitiy<TId>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GenericRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<TEntity>> GetAllAsync(Func<string> func)
    {
        return (await _applicationDbContext.Connection.QueryAsync<TEntity>(func())).ToList();
    }

    public async Task<TEntity?> GetByIdAsync(Func<string> func, TId id)
    {
        return await _applicationDbContext.Connection.QuerySingleOrDefaultAsync<TEntity?>(func(), new { Id = id });
    }

    public async Task<TId> AddAsync(Func<string> func, TEntity driver)
    {
        return await _applicationDbContext.Connection.ExecuteScalarAsync<TId>(func(), driver);
    }

    public async Task UpdateAsync(Func<string> func, TEntity driver)
    {
        await _applicationDbContext.Connection.ExecuteAsync(func(), driver);
    }

    public async Task DeleteAsync(Func<string> func, TId id)
    {
        await _applicationDbContext.Connection.ExecuteAsync(func(), new { Id = id });
    }
}


