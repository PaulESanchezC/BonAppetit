using Microsoft.AspNetCore.Identity;

namespace Models.ApplicationUserModels;

public class ApplicationUser : IdentityUser
{
    public string FristName { get; set; }
    public string LastName { get; set; }
}