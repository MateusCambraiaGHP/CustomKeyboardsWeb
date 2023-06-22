using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers.GetCustomerById
{
    public record GetCustumerByIdQuery(int id) : IRequest<CustomerDto>;
}
