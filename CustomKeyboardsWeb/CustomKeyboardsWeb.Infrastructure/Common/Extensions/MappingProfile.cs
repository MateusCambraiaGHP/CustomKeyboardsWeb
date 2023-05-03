using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
