using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Queries.GetCustomerList
{
    public record GetCustomerListQuery() : IRequest<List<CustomerDto>>;
}
