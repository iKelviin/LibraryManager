using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using LibraryManager.Core.Services;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Utilizar o mesmo algoritmo para criar o hash da senha
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        // Buscar no banco de dados um User que tenha email e senha em formato hash
        var user = await _userRepository.GetUserByEmailAndPassword(request.Email, passwordHash);
        
        // Se nao existir, erro no login
        if (user == null) return ResultViewModel<LoginUserViewModel>.Error("User not found.");

        // Se existir, gera o token usando os dados do usuario.
        var token = _authService.GenerateJwtToken(user.Email, user.Role);
        var model = new LoginUserViewModel(user.Email, token);
        
        return ResultViewModel<LoginUserViewModel>.Success(model);
    }
}