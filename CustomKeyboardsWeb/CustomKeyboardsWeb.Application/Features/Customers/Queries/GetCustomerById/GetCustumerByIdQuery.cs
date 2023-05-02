using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Queries.GetCustomerById
{
    public record GetCustumerByIdQuery(int id) : IRequest<CustomerDto>;
}
