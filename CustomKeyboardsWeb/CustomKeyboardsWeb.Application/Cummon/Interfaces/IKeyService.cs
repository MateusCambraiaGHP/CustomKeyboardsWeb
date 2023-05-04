using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey;
using CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IKeyService
    {
        Task<KeyDto> Save(CreateKeyDto model);
        Task<KeyDto> Edit(UpdateKeyDto model);
        Task<KeyDto> FindByIdAsync(int id);
        Task<List<KeyDto>> GetAll();
    }
}
