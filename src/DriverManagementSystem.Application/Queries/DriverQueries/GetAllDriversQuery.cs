using DriverManagementSystem.Application.DTOs.DriverDTOs;
using MediatR;

namespace DriverManagementSystem.Application.Queries.DriverQueries;

public class GetAllDriversQuery : IRequest<IEnumerable<DriverDto>>
{
}
