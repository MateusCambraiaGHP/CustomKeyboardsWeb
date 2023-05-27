using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard;
using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions.MappingProfiles
{
    public class KeyboardMappingProfile : Profile
    {
        public KeyboardMappingProfile()
        {
            CreateMap<Keyboard, KeyboardDto>().ReverseMap();
            CreateMap<CreateKeyboardDto, KeyboardDto>();
            CreateMap<CreateKeyboardDto, Keyboard>();
            CreateMap<UpdateKeyboardDto, KeyboardDto>();
            CreateMap<UpdateKeyboardDto, Keyboard>();
        }
    }
}
