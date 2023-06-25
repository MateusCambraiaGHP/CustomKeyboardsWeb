using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.Validations.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers
{
    public class UpdateCustomerHandler : Handler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                Customer customerMap = _mapper.Map<Customer>(request.CustomerViewModel);
                customerMap.CreatedAt = DateTime.UtcNow;
                customerMap.CreatedBy = "Administrator";
                await _customerRepository.Update(customerMap);
                await _unitOfWork.CommitChangesAsync();
                var customerViewModel = _mapper.Map<CustomerViewModel>(customerMap);

                return new UpdateCustomerCommandResponse(customerViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(UpdateCustomerCommand request)
        {
            var erros = await new UpdateCustomerCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
