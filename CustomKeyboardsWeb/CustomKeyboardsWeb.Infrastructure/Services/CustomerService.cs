using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Save(CreateCustomerDto model)
        {
            var customer = Customer.Create(
                Name.Create(model.Name),
                FantasyName.Create(model.FantasyName),
                Cep.Create(model.Cep),
                Address.Create(model.Adress),
                FederativeUnit.Create(model.FederativeUnit),
                Phone.Create(model.Phone),
                model.Active);

            await _customerRepository.Create(customer);
            CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public async Task<CustomerDto> Edit(UpdateCustomerDto model)
        {
            Customer customerMap = _mapper.Map<Customer>(model);
            customerMap.CreatedAt = DateTime.UtcNow;
            customerMap.CreatedBy = "Administrator";
            await _customerRepository.Update(customerMap);
            CustomerDto customerDtoMap = _mapper.Map<CustomerDto>(model);
            return customerDtoMap;
        }

        public async Task<CustomerDto> FindByIdAsync(int id)
        {
            var currentCustomer = await _customerRepository.FindById(id);
            var customerMap = _mapper.Map<CustomerDto>(currentCustomer);
            return customerMap;
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            var listCustomer = await _customerRepository.GetAll() ?? new List<Customer>();
            var listCustomerMap = _mapper.Map<List<CustomerDto>>(listCustomer);
            return listCustomerMap;
        }
    }
}