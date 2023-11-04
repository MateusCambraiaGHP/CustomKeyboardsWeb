using AutoMapper;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
        }
    }
}
