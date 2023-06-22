using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards.UpdateKeyboard;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
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
