using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers.GetCustomerList
{
    public record GetCustomerListQuery() : IRequest<List<CustomerDto>>;
}
