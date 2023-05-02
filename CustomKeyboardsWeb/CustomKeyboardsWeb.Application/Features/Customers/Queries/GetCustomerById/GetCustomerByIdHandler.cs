using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustumerByIdQuery, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(GetCustumerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.FindByIdAsync(request.id);
            return customer;
        }
    }
}
