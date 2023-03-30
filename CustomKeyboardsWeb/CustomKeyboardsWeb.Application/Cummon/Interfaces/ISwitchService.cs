using CustomKeyboardsWeb.Application.Dto;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ISwitchService
    {
        Task<SwitchDto> Save(SwitchDto model);
        Task<SwitchDto> Edit(SwitchDto model);
        Task<SwitchDto> FindByIdAsync(int id);
        Task<List<SwitchDto>> GetAll();
    }
}
