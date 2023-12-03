using AutoMapper;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using Switch = CustomKeyboardsWeb.Domain.Primitives.Entities.Switch;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class SwitchMappingProfile : Profile
    {
        public SwitchMappingProfile()
        {
            CreateMap<Switch, SwitchViewModel>().ReverseMap();
        }
    }
}
