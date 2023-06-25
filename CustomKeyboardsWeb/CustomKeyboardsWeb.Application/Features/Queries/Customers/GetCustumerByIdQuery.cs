using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers
{
    public class GetCustumerByIdQuery : Query<GetCustomerByIdQueryResponse> 
    {
        public int IdCustomer { get; set; }

        public GetCustumerByIdQuery(int idCustomer) => IdCustomer = idCustomer;
    }
}
