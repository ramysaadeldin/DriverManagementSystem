using DriverManagementSystem.Application.DTOs.DriverDTOs;
using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Common.Constants;
using DriverManagementSystem.Domain.Exceptions;
using DriverManagementSystem.Domain.Repositories;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverDto>
{
    private readonly IDriverRepository _driverRepository;

    public GetDriverByIdQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<DriverDto> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetByIdAsync(request.Id);
        if (driver == null)
            throw new NotFoundException(string.Format(ErrorMessages.DriverNotFound, request.Id));

        return new DriverDto
        {
            Id = driver.Id,
            FirstName = driver.FirstName,
            LastName = driver.LastName,
            Email = driver.Email,
            PhoneNumber = driver.PhoneNumber
        };
    }
}
