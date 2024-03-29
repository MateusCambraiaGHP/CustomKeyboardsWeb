﻿using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class KeyboardMappingProfile : Profile
    {
        public KeyboardMappingProfile()
        {
            CreateMap<Keyboard, KeyboardViewModel>().ReverseMap();
            CreateMap<Keyboard, UpdateKeyboardDto>().ReverseMap();
        }
    }
}
