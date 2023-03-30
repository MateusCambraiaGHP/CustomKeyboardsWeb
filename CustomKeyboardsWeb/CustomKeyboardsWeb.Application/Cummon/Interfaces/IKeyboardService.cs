using CustomKeyboardsWeb.Application.Dto;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IKeyboardService
    {
        Task<KeyboardDto> Save(KeyboardDto model);
        Task<KeyboardDto> Edit(KeyboardDto model);
        Task<KeyboardDto> FindByIdAsync(int id);
        Task<List<KeyboardDto>> GetAll();
    }
}
