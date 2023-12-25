using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Suppliers
{
    public class GetSupplierListHandler : Handler<GetSupplierListQuery, GetSupplierListQueryResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICacheService _cacheService;

        public GetSupplierListHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            ICacheService cacheService)
            : base(mapper)
        {
            _supplierRepository = supplierRepository;
            _cacheService = cacheService;
        }

        public override async Task<GetSupplierListQueryResponse> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listSupplier = await _supplierRepository.GetAsync(null, null, null);
                var listSupplierMap = _mapper.Map<List<SupplierViewModel>>(listSupplier);

                _cacheService.SetPost<SupplierViewModel>(nameof(SupplierViewModel), listSupplierMap);
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
