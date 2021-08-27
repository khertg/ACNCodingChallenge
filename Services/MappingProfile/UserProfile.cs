using AutoMapper;
using Domain;
using Services.DTO;

namespace Services.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
