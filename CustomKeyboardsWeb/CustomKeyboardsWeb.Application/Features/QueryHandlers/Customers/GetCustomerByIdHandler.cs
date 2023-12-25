using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Customers
{
    public class GetCustomerByIdHandler : Handler<GetCustumerByIdQuery, GetCustomerByIdQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
            : base(mapper)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<GetCustomerByIdQueryResponse> Handle(GetCustumerByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentCustomer = await _customerRepository.GetAsync(cu => cu.Id == request.IdCustomer, null, null);
                var customerMap = _mapper.Map<CustomerViewModel>(currentCustomer.FirstOrDefault());

                return new GetCustomerByIdQueryResponse(customerMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetCustumerByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
