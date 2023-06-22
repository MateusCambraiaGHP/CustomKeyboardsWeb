using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers.UpdateCustomer
{
    public record UpdateCustomerCommand(UpdateCustomerDto CustomerDto) : IRequest<CustomerDto>;
}
