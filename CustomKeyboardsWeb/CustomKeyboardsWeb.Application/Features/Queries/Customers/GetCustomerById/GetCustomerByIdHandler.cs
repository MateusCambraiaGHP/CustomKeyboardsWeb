using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustumerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustumerByIdQuery request, CancellationToken cancellationToken)
        {
            var currentCustomer = await _customerRepository.FindById(request.id);
            var customerMap = _mapper.Map<CustomerDto>(currentCustomer);
            return customerMap;
        }
    }
}
