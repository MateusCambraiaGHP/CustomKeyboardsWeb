using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IKeyboardService
    {
        Task<KeyboardDto> Save(CreateKeyboardDto model);
        Task<KeyboardDto> Edit(UpdateKeyboardDto model);
        Task<KeyboardDto> FindByIdAsync(int id);
        Task<List<KeyboardDto>> GetAll();
    }
}
