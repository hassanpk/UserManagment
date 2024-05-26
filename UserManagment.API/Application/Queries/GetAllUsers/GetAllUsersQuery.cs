using MediatR;
using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDetailsViewModel>>
    {
    }
}