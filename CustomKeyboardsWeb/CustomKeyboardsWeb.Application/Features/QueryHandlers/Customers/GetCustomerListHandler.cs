using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
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
                var customerResponse = await _cacheService
                    .GetAsync<GetCustomerListQueryResponse>("customers", cancellationToken);

                if (customerResponse is not null) return customerResponse;

                var listCustomer = await _customerRepository.GetAll() ?? new List<Customer>();
                var listCustomerMap = _mapper.Map<List<CustomerViewModel>>(listCustomer);

                customerResponse = new GetCustomerListQueryResponse(listCustomerMap);
                await _cacheService.SetAsync("customers", customerResponse, cancellationToken);

                return new GetCustomerListQueryResponse(listCustomerMap);
            }
            catch (Exception)
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
