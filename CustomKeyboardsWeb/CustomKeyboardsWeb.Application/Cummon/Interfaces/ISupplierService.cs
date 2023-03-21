using CustomKeyboardsWeb.Application.Dto;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDto> Save(SupplierDto model);
        Task<SupplierDto> Edit(SupplierDto model);
        Task<SupplierDto> FindByIdAsync(int id);
        Task<List<SupplierDto>> GetAll();
    }
}
