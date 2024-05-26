using AutoMapper;
using UserManagment.API.Domain.Entities;
using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Presentation.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetailsCreateViewModel, UserDetails>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PassportFilePath, opt => opt.Ignore())
                .ForMember(dest => dest.PhotoFilePath, opt => opt.Ignore());


            CreateMap<UserDetails, UserDetailsViewModel>();
        }
    }
}