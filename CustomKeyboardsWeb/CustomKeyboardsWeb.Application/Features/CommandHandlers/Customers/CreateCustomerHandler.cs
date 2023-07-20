using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.Validations.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
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

        public CreateCustomerHandler(
            ICustomerRepository customerRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

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

                return new CreateCustomerCommandResponse(customerViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(CreateCustomerCommand request)
        {
            var erros = await new CreateCustomerCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
