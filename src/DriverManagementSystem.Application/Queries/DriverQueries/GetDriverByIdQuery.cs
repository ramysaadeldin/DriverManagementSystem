using DriverManagementSystem.Application.DTOs.DriverDTOs;
using MediatR;

namespace DriverManagementSystem.Application.Queries.DriverQueries;

public class GetDriverByIdQuery : IRequest<DriverDto>
{
    public long Id { get; }

    public GetDriverByIdQuery(long id)
    {
        Id = id;
    }
}
