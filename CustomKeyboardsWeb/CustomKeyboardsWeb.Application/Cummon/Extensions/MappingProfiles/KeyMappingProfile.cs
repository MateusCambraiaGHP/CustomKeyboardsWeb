using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class KeyMappingProfile : Profile
    {
        public KeyMappingProfile()
        {
            CreateMap<Key, KeyViewModel>().ReverseMap();
            CreateMap<Key, UpdateKeyDto>().ReverseMap();
        }
    }
}
