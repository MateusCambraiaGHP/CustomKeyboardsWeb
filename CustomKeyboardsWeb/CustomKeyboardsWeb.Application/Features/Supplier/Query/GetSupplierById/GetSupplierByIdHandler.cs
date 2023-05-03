using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Query.GetSupplierById
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
    {
        private readonly ISupplierService _supplierService;

        public GetSupplierByIdHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        public Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var currentSupplier = _supplierService.FindByIdAsync(request.id);
            return currentSupplier;
        }
    }
}
