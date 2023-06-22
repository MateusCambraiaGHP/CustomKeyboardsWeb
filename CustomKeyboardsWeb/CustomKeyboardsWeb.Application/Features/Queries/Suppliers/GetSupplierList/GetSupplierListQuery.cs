using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Suppliers.GetSupplierList
{
    public record GetSupplierListQuery() : IRequest<List<SupplierDto>>;
}
