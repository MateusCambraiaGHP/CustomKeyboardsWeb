using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>();
        }
    }
}
