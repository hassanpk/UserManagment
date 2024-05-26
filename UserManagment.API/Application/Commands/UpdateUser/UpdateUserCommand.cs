using MediatR;
using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public UserDetailsCreateViewModel UserInfo { get; set; }
        public IFormFile PassportFile { get; set; }
        public IFormFile PersonPhoto { get; set; }
    }
}