using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Suppliers
{
    public class GetSupplierByIdQuery : Query<GetSupplierByIdQueryResponse>
    {
        public Guid IdSupplier { get; set; }
        public GetSupplierByIdQuery(Guid idSupplier) => IdSupplier = idSupplier;
    }
}
