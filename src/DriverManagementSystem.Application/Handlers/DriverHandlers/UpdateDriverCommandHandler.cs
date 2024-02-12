using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Common.Constants;
using DriverManagementSystem.Domain.Exceptions;
using DriverManagementSystem.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IValidator<UpdateDriverCommand> _validator;


    public UpdateDriverCommandHandler(IDriverRepository driverRepository,
        IValidator<UpdateDriverCommand> validator)
    {
        _driverRepository = driverRepository;
        _validator = validator;
    }

    public async Task Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var driver = await _driverRepository.GetByIdAsync(request.Id);
        if (driver == null)
            throw new NotFoundException(string.Format(ErrorMessages.DriverNotFound, request.Id));


        driver.UpdateDriver(request.FirstName, request.LastName, request.Email, request.PhoneNumber);

        await _driverRepository.UpdateAsync(driver);
    }
}
