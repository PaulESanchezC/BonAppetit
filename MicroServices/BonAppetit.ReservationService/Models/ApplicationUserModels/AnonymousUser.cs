using System.ComponentModel.DataAnnotations;

namespace Models.ApplicationUserModels;

public class AnonymousUser : IApplicationUserBase
{
    [Key]
    public int ApplicationUserId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
}
