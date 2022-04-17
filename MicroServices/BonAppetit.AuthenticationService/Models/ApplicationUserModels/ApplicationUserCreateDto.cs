using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.ApplicationUserModels;

public class ApplicationUserCreateDto
{
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string PhoneNumber { get; set; }

    [Required(AllowEmptyStrings = false)]
    [EmailAddress]
    public string UserName { get; set; }

    [PasswordPropertyText]
    public string Password { get; set; }

    [PasswordPropertyText]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}