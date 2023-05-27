using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer;
using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CreateCustomerDto, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, CustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
