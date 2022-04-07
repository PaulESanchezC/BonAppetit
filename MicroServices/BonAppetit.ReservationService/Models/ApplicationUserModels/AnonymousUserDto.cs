namespace Models.ApplicationUserModels;

public class AnonymousUserDto : IApplicationUserBase
{
    public string? ApplicationUserId { get; set; } = null;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
