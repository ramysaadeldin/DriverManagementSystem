using MediatR;

namespace DriverManagementSystem.Application.Queries.DriverQueries;

public class GetAlphabetizedUserNamesQuery : IRequest<IEnumerable<string>>
{
}
