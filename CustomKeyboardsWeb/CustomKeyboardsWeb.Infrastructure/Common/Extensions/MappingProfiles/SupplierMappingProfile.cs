using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.CreateSupplier;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.UpdateSupplier;
using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions.MappingProfiles
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
