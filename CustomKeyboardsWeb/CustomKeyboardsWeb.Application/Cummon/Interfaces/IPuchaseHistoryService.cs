using CustomKeyboardsWeb.Application.Dto;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IPuchaseHistoryService
    {
        Task<PuchaseHistoryDto> Save(PuchaseHistoryDto model);
        Task<PuchaseHistoryDto> Edit(PuchaseHistoryDto model);
        Task<PuchaseHistoryDto> FindByIdAsync(int id);
        Task<List<PuchaseHistoryDto>> GetAll();
    }
}
