using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Customers
{
    public class GetCustomerByIdQueryResponse : BaseHandlerResponse
    {
        public CustomerViewModel Customer { get; set; }

        public GetCustomerByIdQueryResponse()
            : base() { }

        public GetCustomerByIdQueryResponse(CustomerViewModel customerViewModel)
            : base("Cliente encontrado com sucesso") => Customer = customerViewModel;

        public GetCustomerByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
