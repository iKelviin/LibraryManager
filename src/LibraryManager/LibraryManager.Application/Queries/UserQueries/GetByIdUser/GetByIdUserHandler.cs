using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetByIdUser;

public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, ResultViewModel<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetByIdUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<UserViewModel>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user is null) return ResultViewModel<UserViewModel>.Error("User not found.");

        var model = UserViewModel.FromEntity(user);
        return ResultViewModel<UserViewModel>.Success(model);
    }
}