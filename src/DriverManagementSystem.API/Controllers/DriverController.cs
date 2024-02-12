using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Application.DTOs.DriverDTOs;
using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Common;
using DriverManagementSystem.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriverManagementSystem.API.Controllers;

public class DriverController : Controller
{
    private readonly IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(DriverApiRoutes.CreateDriver)]
    public async Task<IActionResult> Create([FromBody] CreateDriverCommand command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse<object>(default, true));
    }

    [HttpGet(DriverApiRoutes.GetById)]
    public async Task<IActionResult> GetById([FromRoute] long id, CancellationToken cancellationToken=default)
    {
        var query = new GetDriverByIdQuery(id);
        var driver = await _mediator.Send(query, cancellationToken);
        return Ok(new ApiResponse<DriverDto>(driver));
    }

    [HttpGet(DriverApiRoutes.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken=default)
    {
        var query = new GetAllDriversQuery();
        var drivers = await _mediator.Send(query, cancellationToken);
        return Ok(new ApiResponse<IEnumerable<DriverDto>>(drivers));
    }

    [HttpPut(DriverApiRoutes.Update)]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateDriverCommand command, CancellationToken cancellationToken = default)
    {
        command.Id = id;
        await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse<object>(default, true));
    }

    [HttpDelete(DriverApiRoutes.Delete)]
    public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteDriverCommand(id);
        await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse<object>(default, true));
    }

    [HttpPost(DriverApiRoutes.InsertRandomNames)]
    public async Task<IActionResult> InsertRandomNames(CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new InsertRandomNamesCommand(), cancellationToken);
        return Ok(new ApiResponse<object>(default, true));
    }

    [HttpGet(DriverApiRoutes.GetAlphabetizedUserNames)]
    public async Task<IActionResult> GetAlphabetizedUserNames(CancellationToken cancellationToken = default)
    {
        return Ok(new ApiResponse<IEnumerable<string>>(await _mediator.Send(new GetAlphabetizedUserNamesQuery(), cancellationToken)));

    }

    [HttpGet(DriverApiRoutes.GetAlphabetizedUserName)]
    public async Task<IActionResult> GetAlphabetizedUserName([FromRoute] long userId, CancellationToken cancellationToken=default)
    {
        return Ok(new ApiResponse<string>(await _mediator.Send(new GetAlphabetizedUserNameQuery { UserId = userId }, cancellationToken)));
    }
}

