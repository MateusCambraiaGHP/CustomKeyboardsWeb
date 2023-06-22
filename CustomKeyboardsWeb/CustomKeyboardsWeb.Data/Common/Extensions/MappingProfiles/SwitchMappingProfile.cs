using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies.CreateSwitch;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies.UpdateSwitch;
using Switch = CustomKeyboardsWeb.Domain.Primitives.Entities.Switch;

namespace CustomKeyboardsWeb.Data.Common.Extensions.MappingProfiles
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
