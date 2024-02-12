using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Common.Constants;
using DriverManagementSystem.Domain.Exceptions;
using DriverManagementSystem.Domain.Repositories;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class GetAlphabetizedUserNameQueryHandler : IRequestHandler<GetAlphabetizedUserNameQuery, string>
{
    private readonly IDriverRepository _driverRepository;

    public GetAlphabetizedUserNameQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<string> Handle(GetAlphabetizedUserNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _driverRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException(string.Format(ErrorMessages.DriverNotFound, request.UserId));

        return $"{user.FirstName} {user.LastName}";
    }
}

