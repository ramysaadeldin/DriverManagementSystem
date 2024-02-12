using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Domain.Entities;
using DriverManagementSystem.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IValidator<CreateDriverCommand> _validator;

    public CreateDriverCommandHandler(IDriverRepository driverRepository,
        IValidator<CreateDriverCommand> validator
        )
    {
        _driverRepository = driverRepository;
        _validator = validator;
    }

    public async Task Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var driver = new Driver(request.FirstName, request.LastName, request.Email, request.PhoneNumber);

        await _driverRepository.AddAsync(driver);
    }
}
