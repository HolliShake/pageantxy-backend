﻿

using Microsoft.AspNetCore.Identity;

namespace APP.Dto.UserDto;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Picture { get; set; }
    public string Role { get; set; }
    public bool IsAdminVerified { get; set; } = false;
}