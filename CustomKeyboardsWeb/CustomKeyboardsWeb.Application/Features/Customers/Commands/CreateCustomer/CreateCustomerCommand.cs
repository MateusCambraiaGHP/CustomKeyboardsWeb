using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer
{
    public record class CreateCustomerCommand(CustomerDto createCustomerDto) : IRequest<CustomerDto>;
}
