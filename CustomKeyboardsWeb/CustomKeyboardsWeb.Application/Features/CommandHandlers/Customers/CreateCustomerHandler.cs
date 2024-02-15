using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Events;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.Validations.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers
{
    public class CreateCustomerHandler : Handler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
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
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create customer", request.ValidationResult);

                var customer = Customer.Create(
                            Name.Create(request.CustomerDto.Name),
                            FantasyName.Create(request.CustomerDto.FantasyName),
                            Cep.Create(request.CustomerDto.Cep),
                            Address.Create(request.CustomerDto.Address),
                            FederativeUnit.Create(request.CustomerDto.FederativeUnit),
                Phone.Create(request.CustomerDto.Phone),
                request.CustomerDto.Active);

                customer.AddEvent(new TrySendEmailEvent("Cliente criado com sucesso"));
                await _customerRepository.Create(customer);
                await _unitOfWork.CommitChangesAsync();
                _cacheService.RemovePost(nameof(CustomerViewModel), nameof(CustomerViewModel));
                var customerViewModel = _mapper.Map<CustomerViewModel>(customer);

                return new CreateCustomerCommandResponse(customerViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateCustomerCommand request)
        {
            var erros = new CreateCustomerCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
