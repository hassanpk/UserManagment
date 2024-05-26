// Application/Commands/CreateUserCommandHandler.cs
using AutoMapper;
using MediatR;
using UserManagment.API.Domain.Entities;
using UserManagment.API.Infrastructure.FileStorage;
using UserManagment.API.Infrastructure.Repositories;

namespace UserManagment.API.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IFileStorageService fileStorageService, IMapper mapper)
        {
            _userRepository = userRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDetails = _mapper.Map<UserDetails>(request.UserInfo);

            userDetails.PassportFilePath = await _fileStorageService.UploadFileAsync(request.PassportFile);
            userDetails.PhotoFilePath = await _fileStorageService.UploadFileAsync(request.PersonPhoto);

            await _userRepository.AddAsync(userDetails);
            return Unit.Value;
        }       
    }
}
