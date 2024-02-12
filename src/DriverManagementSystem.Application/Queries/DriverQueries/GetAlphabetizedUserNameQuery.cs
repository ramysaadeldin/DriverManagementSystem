using MediatR;

namespace DriverManagementSystem.Application.Queries.DriverQueries;

public class GetAlphabetizedUserNameQuery : IRequest<string>
{
    public long UserId { get; set; }
}
