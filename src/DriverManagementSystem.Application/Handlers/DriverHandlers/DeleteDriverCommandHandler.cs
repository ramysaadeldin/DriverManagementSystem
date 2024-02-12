using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Common.Constants;
using DriverManagementSystem.Domain.Exceptions;
using DriverManagementSystem.Domain.Repositories;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand>
{
    private readonly IDriverRepository _driverRepository;

    public DeleteDriverCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetByIdAsync(request.Id);
        if (driver == null)
            throw new NotFoundException(string.Format(ErrorMessages.DriverNotFound, request.Id));

        await _driverRepository.DeleteAsync(request.Id);
    }
}
