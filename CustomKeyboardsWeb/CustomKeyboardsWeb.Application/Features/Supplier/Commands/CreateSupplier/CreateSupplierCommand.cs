using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Commands.CreateSupplier
{
    public record CreateSupplierCommand(SupplierDto SupplierDto) : IRequest<SupplierDto>;
}
