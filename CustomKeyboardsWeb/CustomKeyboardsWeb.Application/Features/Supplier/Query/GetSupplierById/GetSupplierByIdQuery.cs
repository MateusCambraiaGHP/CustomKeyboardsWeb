using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Query.GetSupplierById
{
    public record GetSupplierByIdCommand(int id) : IRequest<SupplierDto>;
}
