using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Suppliers.GetSupplierById
{
    public record GetSupplierByIdQuery(int id) : IRequest<SupplierDto>;
}
