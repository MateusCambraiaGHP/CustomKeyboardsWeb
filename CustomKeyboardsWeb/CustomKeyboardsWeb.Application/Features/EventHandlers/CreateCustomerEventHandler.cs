using CustomKeyboardsWeb.Application.Features.Events;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;

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
            catch (Exception ex)
            {
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
