using Bogus;
using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Domain.Entities;
using DriverManagementSystem.Domain.Repositories;
using MediatR;

namespace DriverManagementSystem.Application.Handlers.DriverHandlers;

public class InsertRandomNamesCommandHandler : IRequestHandler<InsertRandomNamesCommand>
{
    private static readonly int _rangeStart = 1;
    private static readonly int _rangeEnd = 10;
    private readonly IDriverRepository _driverRepository;

    public InsertRandomNamesCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task Handle(InsertRandomNamesCommand request, CancellationToken cancellationToken)
    {

        var drivers = Enumerable.Range(_rangeStart, _rangeEnd).Select(_ =>
        {
            var faker = new Faker();

            string firstName = faker.Person.FirstName;
            string lastName = faker.Person.LastName;
            string email = faker.Internet.Email();
            string phoneNumber = faker.Phone.PhoneNumber();
            return new Driver(firstName, lastName, email, phoneNumber);
        });

        foreach (var driver in drivers)
        {
            await _driverRepository.AddAsync(driver);
        }
    }
}
