using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand(UpdateSupplierDto UpdateSupplierDto) : IRequest<SupplierDto>;
}
