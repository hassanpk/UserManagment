using AutoMapper;
using MediatR;
using UserManagment.API.Infrastructure.Repositories;
using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            return _mapper.Map<UserDetailsViewModel>(user);
        }
    }
}