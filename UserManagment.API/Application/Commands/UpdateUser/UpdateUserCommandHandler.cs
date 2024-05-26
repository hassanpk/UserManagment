using AutoMapper;
using MediatR;
using UserManagment.API.Infrastructure.FileStorage;
using UserManagment.API.Infrastructure.Repositories;

namespace UserManagment.API.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IFileStorageService fileStorageService, IMapper mapper)
        {
            _userRepository = userRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found");

            var userDetails = _mapper.Map(request.UserInfo, existingUser);

            // Handle file uploads
            userDetails.PassportFilePath = request.PassportFile != null
                ? await _fileStorageService.UploadFileAsync(request.PassportFile)
                : userDetails.PassportFilePath;
            userDetails.PhotoFilePath = request.PersonPhoto != null
                ? await _fileStorageService.UploadFileAsync(request.PersonPhoto)
                : userDetails.PhotoFilePath;

            await _userRepository.UpdateAsync(userDetails);
            return Unit.Value;
        }
    }
}