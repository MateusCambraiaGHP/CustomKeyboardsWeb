using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Suppliers.GetSupplierById
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var currentSupplier = await _supplierRepository.FindById(request.id);
            var supplierMap = _mapper.Map<SupplierDto>(currentSupplier);
            return supplierMap;
        }
    }
}
