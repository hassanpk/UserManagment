// Application/Commands/CreateUserCommand.cs
using MediatR;
using UserManagment.API.Presentation.ViewModels;


namespace UserManagment.API.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public UserDetailsCreateViewModel UserInfo { get; set; }
        public IFormFile PassportFile { get; set; }
        public IFormFile PersonPhoto { get; set; }
    }
}
