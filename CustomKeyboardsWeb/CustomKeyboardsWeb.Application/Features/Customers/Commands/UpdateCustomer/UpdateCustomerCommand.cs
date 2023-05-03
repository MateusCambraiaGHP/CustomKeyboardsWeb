using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(CustomerDto CustomerDto) : IRequest<CustomerDto>;
}
