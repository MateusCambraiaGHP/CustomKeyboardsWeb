using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ISwitchService
    {
        Task<SwitchDto> Save(CreateSwitchDto model);
        Task<SwitchDto> Edit(UpdateSwitchDto model);
        Task<SwitchDto> FindByIdAsync(int id);
        Task<List<SwitchDto>> GetAll();
    }
}
