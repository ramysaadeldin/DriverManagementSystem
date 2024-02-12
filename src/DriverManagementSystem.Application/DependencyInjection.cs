using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Application.DTOs.DriverDTOs;
using DriverManagementSystem.Application.Handlers.DriverHandlers;
using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Application.Validators.DriverValidators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DriverManagementSystem.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        RegisterCommandHandler(services);

        RegisterQueryHandler(services);

        RegisterCommandValidator(services);
    }


    private static void RegisterCommandHandler(IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateDriverCommand>, CreateDriverCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteDriverCommand>, DeleteDriverCommandHandler>();

        services.AddScoped<IRequestHandler<GetDriverByIdQuery, DriverDto>, GetDriverByIdQueryHandler>();
        services.AddScoped<IRequestHandler<InsertRandomNamesCommand>, InsertRandomNamesCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateDriverCommand>, UpdateDriverCommandHandler>();

        services.AddScoped<IRequestHandler<GetAlphabetizedUserNameQuery, string>, GetAlphabetizedUserNameQueryHandler>();
        services.AddScoped<IRequestHandler<GetAlphabetizedUserNamesQuery, IEnumerable<string>>, GetAlphabetizedUserNamesQueryHandler>();    
    }

    private static void RegisterQueryHandler(IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<GetAllDriversQuery, IEnumerable<DriverDto>>, GetAllDriversQueryHandler>();
    }

    private static void RegisterCommandValidator(IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateDriverCommand>, CreateDriverCommandValidator>();
        services.AddScoped<IValidator<UpdateDriverCommand>, UpdateDriverCommandValidator>();
    }


}
