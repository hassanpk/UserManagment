using MediatR;
using UserManagment.API.Infrastructure.Repositories;

namespace UserManagment.API.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        { 
            var existingUser = await _userRepository.GetByIdAsync(request.Id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found");
                
            await _userRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}