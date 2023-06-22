using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Customers.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Commands.Customers.UpdateCustomer;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
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
