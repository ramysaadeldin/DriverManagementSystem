using Dapper;
using DriverManagementSystem.Domain.Entities;
using DriverManagementSystem.Domain.Repositories;
using DriverManagementSystem.Infrastructure.DataAccess;
using System.Data;
using System.Data.Common;

namespace DriverManagementSystem.Infrastructure.Repositories;

public class DriverRepository : GenericRepository<Driver,long>, IDriverRepository
{
    private readonly DriverQueries _driverQueries;

    public DriverRepository(ApplicationDbContext applicationDbContext,
        DriverQueries driverQueries) : base(applicationDbContext)
    {
        _driverQueries = driverQueries;
    }

    public async Task<List<Driver>> GetAllAsync()
    {
        return await base.GetAllAsync(_driverQueries.GetAll);
    }

    public async Task<Driver?> GetByIdAsync(long id)
    {
        return await base.GetByIdAsync(_driverQueries.GetById, id);
    }

    public async Task<long> AddAsync(Driver driver)
    {
        return await base.AddAsync(_driverQueries.Insert, driver);
    }

    public async Task UpdateAsync(Driver driver)
    {
        await base.UpdateAsync(_driverQueries.Update, driver);
    }

    public async Task DeleteAsync(long id)
    {
        await base.DeleteAsync(_driverQueries.Delete, id);
    }
}