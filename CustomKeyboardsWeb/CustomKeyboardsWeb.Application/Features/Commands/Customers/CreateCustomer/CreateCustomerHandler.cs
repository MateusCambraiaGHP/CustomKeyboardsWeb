using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandler(
            ICustomerRepository customerRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = Customer.Create(
                            Name.Create(request.createCustomerDto.Name),
                            FantasyName.Create(request.createCustomerDto.FantasyName),
                            Cep.Create(request.createCustomerDto.Cep),
                            Address.Create(request.createCustomerDto.Adress),
                            FederativeUnit.Create(request.createCustomerDto.FederativeUnit),
                            Phone.Create(request.createCustomerDto.Phone),
                            request.createCustomerDto.Active);

                await _customerRepository.Create(customer);
                await _unitOfWork.CommitChangesAsync();
                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
                return customerDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
