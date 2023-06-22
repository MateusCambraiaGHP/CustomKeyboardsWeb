using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Customer customerMap = _mapper.Map<Customer>(request.CustomerDto);
                customerMap.CreatedAt = DateTime.UtcNow;
                customerMap.CreatedBy = "Administrator";
                await _customerRepository.Update(customerMap);
                await _unitOfWork.CommitChangesAsync();
                CustomerDto customerDtoMap = _mapper.Map<CustomerDto>(customerMap);
                return customerDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
