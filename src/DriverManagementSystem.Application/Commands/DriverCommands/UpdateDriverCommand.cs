using MediatR;
using System.Text.Json.Serialization;

namespace DriverManagementSystem.Application.Commands.DriverCommands;

public class UpdateDriverCommand : IRequest
{
    [JsonIgnore]
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
