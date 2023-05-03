using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierService _supplierService;

        public CreateSupplierHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var currentSupplier = await _supplierService.Save(request.SupplierDto);
            return currentSupplier;
        }
    }
}
