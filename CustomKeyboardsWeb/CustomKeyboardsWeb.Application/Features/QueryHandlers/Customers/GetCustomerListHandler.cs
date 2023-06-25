using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Customers
{
    public class GetCustomerListHandler : Handler<GetCustomerListQuery, GetCustomerListQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
            : base(mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public override async Task<GetCustomerListQueryResponse> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listCustomer = await _customerRepository.GetAll() ?? new List<Customer>();
                var listCustomerMap = _mapper.Map<List<CustomerViewModel>>(listCustomer);

                return new GetCustomerListQueryResponse(listCustomerMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetCustomerListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
