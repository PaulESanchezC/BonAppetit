using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Models.ResponseModels;

namespace Models.AuthenticationModels;

public class LoginAttempt
{
    [Required(AllowEmptyStrings = false)]
    [EmailAddress]
    public string Username { get; set; }

    [Required(AllowEmptyStrings = false)]
    [PasswordPropertyText]
    public string Password { get; set; }
}