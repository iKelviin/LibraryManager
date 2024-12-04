using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<Guid>>
{
    public InsertUserCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get;  set; }
    public string Email { get;  set; }
    
    public User ToEntity() => new(Name, Email);
}