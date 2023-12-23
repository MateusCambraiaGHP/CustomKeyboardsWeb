using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.Validations.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers
{
    public class UpdateCustomerHandler : Handler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateCustomerHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICacheService cacheService)
            : base(mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public override async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update customer", request.ValidationResult);

                Customer customerMap = _mapper.Map<Customer>(request.CustomerDto);
                customerMap.CreatedBy = "Administrator";
                await _customerRepository.Update(customerMap);
                await _unitOfWork.CommitChangesAsync();
                var customerViewModel = _mapper.Map<CustomerViewModel>(customerMap);
                _cacheService.RemovePost(nameof(CustomerViewModel), nameof(CustomerViewModel));

                return new UpdateCustomerCommandResponse(customerViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateCustomerCommand request)
        {
            var erros = new UpdateCustomerCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
