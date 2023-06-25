using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers
{
    public class GetCustomerListQuery : Query<GetCustomerListQueryResponse>
    {
        public GetCustomerListQuery() { }
    }
}
