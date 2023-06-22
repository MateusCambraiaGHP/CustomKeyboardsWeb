using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers.GetCustomerList
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var listCustomer = await _customerRepository.GetAll() ?? new List<Customer>();
            var listCustomerMap = _mapper.Map<List<CustomerDto>>(listCustomer);
            return listCustomerMap;
        }
    }
}
