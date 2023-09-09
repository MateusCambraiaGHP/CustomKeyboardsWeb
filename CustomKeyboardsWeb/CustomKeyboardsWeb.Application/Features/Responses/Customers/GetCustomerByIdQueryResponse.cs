using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Customers
{
    public class GetCustomerByIdQueryResponse : BaseHandlerResponse
    {
        public CustomerViewModel Customer { get; set; }

        public GetCustomerByIdQueryResponse()
            : base() { }

        public GetCustomerByIdQueryResponse(CustomerViewModel customerViewModel)
            : base("Cliente criado com sucesso") => Customer = customerViewModel;

        public GetCustomerByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
