using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Suppliers
{
    public class GetSupplierByIdHandler : Handler<GetSupplierByIdQuery, GetSupplierByIdQueryResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
            :base(mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public override async Task<GetSupplierByIdQueryResponse> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentSupplier = await _supplierRepository.FindById(request.IdSupplier);
                var supplierMap = _mapper.Map<SupplierViewModel>(currentSupplier);
                return new GetSupplierByIdQueryResponse(supplierMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetSupplierByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
