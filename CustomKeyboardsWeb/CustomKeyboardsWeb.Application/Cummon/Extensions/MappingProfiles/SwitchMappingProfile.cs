﻿using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using Switch = CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies.Switch;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class SwitchMappingProfile : Profile
    {
        public SwitchMappingProfile()
        {
            CreateMap<Switch, SwitchViewModel>().ReverseMap();
            CreateMap<Switch, UpdateSwitchDto>().ReverseMap();
        }
    }
}
