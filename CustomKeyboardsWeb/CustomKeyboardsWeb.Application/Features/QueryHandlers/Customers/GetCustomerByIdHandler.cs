using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Customers
{
    public class GetCustomerByIdHandler : Handler<GetCustumerByIdQuery, GetCustomerByIdQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
            : base(mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public override async Task<GetCustomerByIdQueryResponse> Handle(GetCustumerByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentCustomer = await _customerRepository.FindById(request.IdCustomer);
                var customerMap = _mapper.Map<CustomerViewModel>(currentCustomer);

                return new GetCustomerByIdQueryResponse(customerMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetCustumerByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
