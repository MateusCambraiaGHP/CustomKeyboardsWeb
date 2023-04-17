using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Entity;

namespace MyHardwareWeb.Infrastructure.Services
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

        public async Task<CustomerDto> Save(CustomerDto model)
        {
            Customer customerMap = _mapper.Map<Customer>(model);
            await _customerRepository.Create(customerMap);
            return model;
        }

        public async Task<CustomerDto> Edit(CustomerDto model)
        {
            Customer customerMap = _mapper.Map<CustomerDto, Customer>(model);
            await _customerRepository.Update(customerMap);
            return model;
        }

        public async Task<CustomerDto> FindByIdAsync(int id)
        {
            var currentCustomer = await _customerRepository.FindById(id) ?? new Customer();
            var customerMap     = _mapper.Map<CustomerDto>(currentCustomer);
            return customerMap;
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            var listCustomer    = await _customerRepository.GetAll() ?? new List<Customer>();
            var listCustomerMap = _mapper.Map<List<CustomerDto>>(listCustomer);
            return listCustomerMap;
        }
    }
}