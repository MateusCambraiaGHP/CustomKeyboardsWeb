using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers.CreateSupplier
{
    public record CreateSupplierCommand(CreateSupplierDto CreateSupplierDto) : IRequest<SupplierDto>;
}
