using DriverManagementSystem.Domain.Entities;

namespace DriverManagementSystem.Domain.Repositories;

public interface IDriverRepository
{
    Task<List<Driver>> GetAllAsync();
    Task<Driver> GetByIdAsync(long id);
    Task<long> AddAsync(Driver driver);
    Task UpdateAsync(Driver driver);
    Task DeleteAsync(long id);
}
