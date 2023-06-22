using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers.CreateCustomer
{
    public record class CreateCustomerCommand(CreateCustomerDto createCustomerDto) : IRequest<CustomerDto>;
}
