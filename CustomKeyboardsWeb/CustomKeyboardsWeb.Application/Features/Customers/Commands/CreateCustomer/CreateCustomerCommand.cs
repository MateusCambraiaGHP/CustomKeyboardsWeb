using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer
{
    public record class CreateCustomerCommand(CreateCustomerDto createCustomerDto) : IRequest<CustomerDto>;
}
