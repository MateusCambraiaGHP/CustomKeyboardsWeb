using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.CreateSupplier;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.UpdateSupplier;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDto> Save(CreateSupplierDto model);
        Task<SupplierDto> Edit(UpdateSupplierDto model);
        Task<SupplierDto> FindByIdAsync(int id);
        Task<List<SupplierDto>> GetAll();
    }
}
