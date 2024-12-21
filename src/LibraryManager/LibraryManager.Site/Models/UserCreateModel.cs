using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Site.Models;

public class UserCreateModel
{
    public UserCreateModel(string name, string email, string password, string role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public string Name { get;  set; }
    public string Email { get;  set; }
    public string Password { get;  set; }
    public string Role { get;  set; }
}