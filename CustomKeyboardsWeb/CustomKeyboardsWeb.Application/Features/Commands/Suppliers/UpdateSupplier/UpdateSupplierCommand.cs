using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers.UpdateSupplier
{
    public record UpdateSupplierCommand(UpdateSupplierDto UpdateSupplierDto) : IRequest<SupplierDto>;
}
