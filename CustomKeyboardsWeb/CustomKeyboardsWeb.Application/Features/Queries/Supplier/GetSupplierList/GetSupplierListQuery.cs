using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Query.GetSupplierList
{
    public record GetSupplierListQuery() : IRequest<List<SupplierDto>>;
}
