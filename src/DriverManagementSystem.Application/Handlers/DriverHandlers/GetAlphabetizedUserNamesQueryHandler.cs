using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Domain.Repositories;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class GetAlphabetizedUserNamesQueryHandler : IRequestHandler<GetAlphabetizedUserNamesQuery, IEnumerable<string>>
{
    private readonly IDriverRepository _driverRepository;

    public GetAlphabetizedUserNamesQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<IEnumerable<string>> Handle(GetAlphabetizedUserNamesQuery request, CancellationToken cancellationToken)
    {
        var users = await _driverRepository.GetAllAsync();
        return users.OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                    .Select(u => $"{u.FirstName} {u.LastName}");
    }
}
