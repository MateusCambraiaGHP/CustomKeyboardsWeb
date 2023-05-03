using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Query.GetSupplierById
{
    public record GetSupplierByIdQuery(int id) : IRequest<SupplierDto>;
}
