using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Supplier.Query.GetSupplierList
{
    public class GetSupplierListHandler : IRequestHandler<GetSupplierListQuery, List<SupplierDto>>
    {
        private readonly ISupplierService _supplierService;

        public GetSupplierListHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<List<SupplierDto>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var currentSupplier = await _supplierService.GetAll();
            return currentSupplier;
        }
    }
}
