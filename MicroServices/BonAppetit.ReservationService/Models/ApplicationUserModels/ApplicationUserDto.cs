namespace Models.ApplicationUserModels;

public class ApplicationUserDto : IApplicationUserBase
{
    public string ApplicationUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}