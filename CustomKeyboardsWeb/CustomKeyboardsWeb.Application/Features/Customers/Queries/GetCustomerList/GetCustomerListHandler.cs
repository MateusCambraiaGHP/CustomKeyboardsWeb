using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<CustomerDto>>
    {
        private readonly ICustomerService _customerservice;

        public GetCustomerListHandler(ICustomerService customerservice)
        {
            _customerservice = customerservice;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _customerservice.GetAll();
        }
    }
}
