using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using LibraryManager.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public InsertUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<ResultViewModel<Guid>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await _userRepository.Exists(request.Email);
        if(exists) return ResultViewModel<Guid>.Error("User with this email already exists");
        
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        request.Password = passwordHash;
        
        var user = request.ToEntity();
        await _userRepository.AddAsync(user);
        return ResultViewModel<Guid>.Success(user.Id);
    }
}