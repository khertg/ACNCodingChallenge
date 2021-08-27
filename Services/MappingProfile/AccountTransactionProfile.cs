using AutoMapper;
using Domain;
using Domain.Enum;
using Services.DTO;
using System;

namespace Services.MappingProfile
{
    public class AccountTransactionProfile : Profile
    {
        public AccountTransactionProfile()
        {
            CreateMap<AccountTransaction, AccountTransactionDTO>()
                .ForMember(dest => dest.Status, act => act.MapFrom(src => Enum.GetName(typeof(TransactionStatus), src.Status))); ;
        }
    }
}
