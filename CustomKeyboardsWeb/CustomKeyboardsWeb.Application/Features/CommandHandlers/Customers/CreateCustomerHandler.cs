using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.Validations.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers
{
    public class CreateCustomerHandler : Handler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public CreateCustomerHandler(
            ICustomerRepository customerRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var customer = Customer.Create(
                            Name.Create(request.CustomerViewModel.Name),
                            FantasyName.Create(request.CustomerViewModel.FantasyName),
                            Cep.Create(request.CustomerViewModel.Cep),
                            Address.Create(request.CustomerViewModel.Address),
                            FederativeUnit.Create(request.CustomerViewModel.FederativeUnit),
                            Phone.Create(request.CustomerViewModel.Phone),
                            request.CustomerViewModel.Active);

                await _customerRepository.Create(customer);
                await _unitOfWork.CommitChangesAsync();
                var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
                await _cacheService.RemoveAsync("customers", cancellationToken); 

                return new CreateCustomerCommandResponse(customerViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override  List<ValidationFailure> Validate(CreateCustomerCommand request)
        {
            var erros = new CreateCustomerCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
