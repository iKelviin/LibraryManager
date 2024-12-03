using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class UserViewModel
{
    public UserViewModel(Guid id, string name, string email, bool active)
    {
        Id = id;
        Name = name;
        Email = email;
        Active = active;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    
    public static UserViewModel FromEntity(User user)
    {
        return new(user.Id, user.Name, user.Email, user.Active);
    } 
}