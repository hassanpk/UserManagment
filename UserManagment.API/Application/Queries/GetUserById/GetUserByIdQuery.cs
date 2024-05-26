using MediatR;
using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
    {
        public int Id { get; set; }
    }
}