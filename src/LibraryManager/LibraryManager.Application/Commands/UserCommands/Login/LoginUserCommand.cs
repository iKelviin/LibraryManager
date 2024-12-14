using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.Login;

public class LoginUserCommand : IRequest<ResultViewModel<LoginUserViewModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}