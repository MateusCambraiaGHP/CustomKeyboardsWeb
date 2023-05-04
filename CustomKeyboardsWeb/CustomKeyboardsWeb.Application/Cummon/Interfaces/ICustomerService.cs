using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> Save(CreateCustomerDto model);
        Task<CustomerDto> Edit(UpdateCustomerDto model);
        Task<CustomerDto> FindByIdAsync(int id);
        Task<List<CustomerDto>> GetAll();
    }
}
