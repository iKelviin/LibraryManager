using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{
    
}