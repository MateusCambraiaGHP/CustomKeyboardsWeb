using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Customers
{
    public class GetCustomerListHandler : Handler<GetCustomerListQuery, GetCustomerListQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetCustomerListHandler(
            ICustomerRepository customerRepository,
            IMapper mapper,
            ICacheService cacheService)
            : base(mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public override async Task<GetCustomerListQueryResponse> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cache = await _cacheService.GetAll<CustomerViewModel>(nameof(CustomerViewModel));
                if (cache != null)
                {
                    var mapRes = cache.ToList();
                    return new GetCustomerListQueryResponse(mapRes);
                }

                var listCustomer = await _customerRepository.GetAsync(null, null, null);
                var listCustomerMap = _mapper.Map<List<CustomerViewModel>>(listCustomer);
                _cacheService.SetPost<CustomerViewModel>(nameof(CustomerViewModel), listCustomerMap);

                return new GetCustomerListQueryResponse(listCustomerMap);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetCustomerListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
