using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Keys.CreateKey;
using CustomKeyboardsWeb.Application.Features.Commands.Keys.UpdateKey;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
{
    public class KeyMappingProfile : Profile
    {
        public KeyMappingProfile()
        {
            CreateMap<Key, KeyDto>().ReverseMap();
            CreateMap<CreateKeyDto, KeyDto>();
            CreateMap<CreateKeyDto, Key>();
            CreateMap<UpdateKeyDto, KeyDto>();
            CreateMap<UpdateKeyDto, Key>();
        }
    }
}
