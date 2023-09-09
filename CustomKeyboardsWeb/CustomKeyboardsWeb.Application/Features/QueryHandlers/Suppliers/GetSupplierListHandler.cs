using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Suppliers
{
    public class GetSupplierListHandler : Handler<GetSupplierListQuery, GetSupplierListQueryResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierListHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
            :base(mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public override async Task<GetSupplierListQueryResponse> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listSupplier = await _supplierRepository.GetAll();
                var listSupplierMap = _mapper.Map<List<SupplierViewModel>>(listSupplier);
                return new GetSupplierListQueryResponse(listSupplierMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetSupplierListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
