﻿using DriverManagementSystem.Domain.Primitives;

namespace DriverManagementSystem.Domain.Entities;

public class Driver : BaseEntitiy<long>
{
    public Driver()
    {
        
    }
    public Driver(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    public void UpdateDriver(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
}

