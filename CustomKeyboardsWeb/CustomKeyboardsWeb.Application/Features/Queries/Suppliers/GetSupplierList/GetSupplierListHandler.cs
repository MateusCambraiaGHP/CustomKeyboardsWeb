using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Suppliers.GetSupplierList
{
    public class GetSupplierListHandler : IRequestHandler<GetSupplierListQuery, List<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierListHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<SupplierDto>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var listSupplier = await _supplierRepository.GetAll();
            var listSupplierMap = _mapper.Map<List<SupplierDto>>(listSupplier);
            return listSupplierMap;
        }
    }
}
