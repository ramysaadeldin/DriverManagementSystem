using DriverManagementSystem.Application.Commands.DriverCommands;
using FluentValidation;

namespace DriverManagementSystem.Application.Validators.DriverValidators;

public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
{
    public UpdateDriverCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        _ = new CreateDriverCommandValidator();
    }
}
