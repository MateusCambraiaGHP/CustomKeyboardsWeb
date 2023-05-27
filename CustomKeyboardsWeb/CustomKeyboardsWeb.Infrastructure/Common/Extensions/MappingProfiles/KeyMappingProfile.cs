using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey;
using CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey;
using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions.MappingProfiles
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
