using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Suppliers
{
    public class GetSupplierByIdQuery : Query<GetSupplierByIdQueryResponse>
    {
        public int IdSupplier { get; set; }
        public GetSupplierByIdQuery(int idSupplier) => IdSupplier = idSupplier;
    }
}
