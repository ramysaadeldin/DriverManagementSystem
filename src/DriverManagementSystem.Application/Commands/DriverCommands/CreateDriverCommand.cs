using MediatR;

namespace DriverManagementSystem.Application.Commands.DriverCommands;

public class CreateDriverCommand : IRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
