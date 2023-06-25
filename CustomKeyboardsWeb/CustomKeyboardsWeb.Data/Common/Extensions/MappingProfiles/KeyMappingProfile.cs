using AutoMapper;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
{
    public class KeyMappingProfile : Profile
    {
        public KeyMappingProfile()
        {
            CreateMap<Key, KeyViewModel>().ReverseMap();
        }
    }
}
