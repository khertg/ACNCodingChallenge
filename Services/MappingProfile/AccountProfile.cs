using AutoMapper;
using Domain;
using Services.DTO;

namespace Services.MappingProfile
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<decimal, AccountBalanceDTO>()
                .ForMember(dest => dest.Balance, act => act.MapFrom(src => src));
            CreateMap<Account, AccountDTO>();
        }
    }
}
