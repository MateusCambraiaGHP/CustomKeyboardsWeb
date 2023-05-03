using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateKeyCommand(CustomerDto CustomerDto) : IRequest<CustomerDto>;
}
