using AutoMapper;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
        }
    }
}
