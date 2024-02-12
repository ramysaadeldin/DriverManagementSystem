using MediatR;

namespace DriverManagementSystem.Application.Commands.DriverCommands;

public class DeleteDriverCommand : IRequest
{
    public long Id { get; set; }

    public DeleteDriverCommand(long id)
    {
        Id = id;
    }
}
