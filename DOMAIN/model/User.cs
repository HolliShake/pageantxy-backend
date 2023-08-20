using Microsoft.AspNetCore.Identity;

namespace DOMAIN.model;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string Picture { get; set; }
    public string Role { get; set; }
    public bool IsAdminVerified { get; set; }
}