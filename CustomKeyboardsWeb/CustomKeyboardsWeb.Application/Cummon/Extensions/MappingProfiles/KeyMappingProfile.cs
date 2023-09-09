using AutoMapper;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class KeyMappingProfile : Profile
    {
        public KeyMappingProfile()
        {
            CreateMap<Key, KeyViewModel>().ReverseMap();
        }
    }
}
