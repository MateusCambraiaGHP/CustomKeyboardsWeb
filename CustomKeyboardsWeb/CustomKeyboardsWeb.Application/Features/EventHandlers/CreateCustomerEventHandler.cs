using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Events;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.EventHandlers
{
    public class CreateCustomerEventHandler : BaseEventHandler<CreateCustomerEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerEventHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task Handle(CreateCustomerEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var customer = Customer.Create(
                    Name.Create(notification.Supplier.Name.ToString()),
                    FantasyName.Create(notification.Supplier.FantasyName.ToString()),
                    Cep.Create(notification.Supplier.Cep.ToString()),
                    Address.Create(notification.Supplier.Address.ToString()),
                    FederativeUnit.Create(notification.Supplier.FederativeUnit.ToString()),
                    Phone.Create(notification.Supplier.Phone.ToString()),
                    notification.Supplier.Active.ToString());

                 _customerRepository.Create(customer);
                _unitOfWork.CommitChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Task.CompletedTask;
        }

        protected override void PostErrorLog(string message)
        {
            throw new NotImplementedException();
        }

        protected override void PostInfoLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
