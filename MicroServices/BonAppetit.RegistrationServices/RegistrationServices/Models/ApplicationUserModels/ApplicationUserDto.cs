using Microsoft.AspNetCore.Identity;

namespace Models.ApplicationUserModels;

public class ApplicationUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
}