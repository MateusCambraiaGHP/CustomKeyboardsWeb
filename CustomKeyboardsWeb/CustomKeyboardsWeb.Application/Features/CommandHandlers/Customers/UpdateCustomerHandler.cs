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
            _cacheService = cacheService;
        }

        public override async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var currentCustomer = await _customerRepository.GetAsync(cu => cu.Id == request.CustomerDto.Id, null, null);
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update customer", request.ValidationResult);

                var customerMap = _mapper.Map(request.CustomerDto, currentCustomer.FirstOrDefault());
                await _customerRepository.Update(customerMap);
                await _unitOfWork.CommitChangesAsync();
                var updatedCustomer = await _customerRepository.GetAsync(cu => cu.Id == request.CustomerDto.Id, null, null);
                var customerViewModel = _mapper.Map<CustomerViewModel>(updatedCustomer.FirstOrDefault());
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
