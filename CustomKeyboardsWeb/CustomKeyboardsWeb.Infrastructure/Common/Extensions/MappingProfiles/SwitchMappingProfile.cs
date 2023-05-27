using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch;
using Switch = CustomKeyboardsWeb.Domain.Primitives.Switch;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions.MappingProfiles
{
    public class SwitchMappingProfile : Profile
    {
        public SwitchMappingProfile()
        {
            CreateMap<Switch, SwitchDto>().ReverseMap();
            CreateMap<CreateSwitchDto, SwitchDto>();
            CreateMap<CreateSwitchDto, Switch>();
            CreateMap<UpdateSwitchDto, SwitchDto>();
            CreateMap<UpdateSwitchDto, Switch>();
        }
    }
}
