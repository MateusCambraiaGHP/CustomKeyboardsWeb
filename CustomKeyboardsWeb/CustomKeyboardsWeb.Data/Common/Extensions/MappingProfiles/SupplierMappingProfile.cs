using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers.CreateSupplier;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers.UpdateSupplier;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<CreateSupplierDto, SupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, SupplierDto>();
            CreateMap<UpdateSupplierDto, Supplier>();
        }
    }
}
