using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Site.Security;

public class User
{

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}