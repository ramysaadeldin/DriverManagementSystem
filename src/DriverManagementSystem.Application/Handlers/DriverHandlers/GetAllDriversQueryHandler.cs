using DriverManagementSystem.Application.DTOs.DriverDTOs;
using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Domain.Repositories;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<DriverDto>>
{
    private readonly IDriverRepository _driverRepository;

    public GetAllDriversQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<IEnumerable<DriverDto>?> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _driverRepository.GetAllAsync();

        return drivers?.Select(s =>
           new DriverDto
           {
               Id = s.Id,
               FirstName = s.FirstName,
               LastName = s.LastName,
               Email = s.Email,
               PhoneNumber = s.PhoneNumber
           });
    }
}
