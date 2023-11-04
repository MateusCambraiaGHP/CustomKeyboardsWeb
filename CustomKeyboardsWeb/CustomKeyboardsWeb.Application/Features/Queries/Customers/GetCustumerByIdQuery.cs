using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers
{
    public class GetCustumerByIdQuery : Query<GetCustomerByIdQueryResponse> 
    {
        public Guid IdCustomer { get; set; }

        public GetCustumerByIdQuery(Guid idCustomer) => IdCustomer = idCustomer;
    }
}
