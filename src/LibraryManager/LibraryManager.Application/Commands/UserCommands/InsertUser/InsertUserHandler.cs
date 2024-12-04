using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<Guid>>
{
    private readonly IUserRepository _userRepository;

    public InsertUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();
        await _userRepository.AddAsync(user);
        return ResultViewModel<Guid>.Success(user.Id);
    }
}