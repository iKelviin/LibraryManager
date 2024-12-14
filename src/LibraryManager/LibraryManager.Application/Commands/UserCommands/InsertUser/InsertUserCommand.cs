using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<Guid>>
{
    public InsertUserCommand(string name, string email, string password, string role)
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
    
    public User ToEntity() => new(Name, Email, Password, Role);
}