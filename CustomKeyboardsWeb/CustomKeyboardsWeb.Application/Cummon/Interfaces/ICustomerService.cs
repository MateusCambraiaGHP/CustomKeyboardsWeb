using CustomKeyboardsWeb.Application.Dto;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> Save(CustomerDto model);
        Task<CustomerDto> Edit(CustomerDto model);
        Task<CustomerDto> FindByIdAsync(int id);
        Task<List<CustomerDto>> GetAll();
    }
}
