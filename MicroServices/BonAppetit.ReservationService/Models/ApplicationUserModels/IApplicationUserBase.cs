namespace Models.ApplicationUserModels;

public interface IApplicationUserBase
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
}