﻿namespace DriverManagementSystem.Application.DTOs.DriverDTOs;

public class DriverDto
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
