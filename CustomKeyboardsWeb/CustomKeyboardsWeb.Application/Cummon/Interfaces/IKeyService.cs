using CustomKeyboardsWeb.Application.Dto;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IKeyService
    {
        Task<KeyDto> Save(KeyDto model);
        Task<KeyDto> Edit(KeyDto model);
        Task<KeyDto> FindByIdAsync(int id);
        Task<List<KeyDto>> GetAll();
    }
}
