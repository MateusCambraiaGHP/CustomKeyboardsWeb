using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Events
{
    public class CreateCustomerEvent : Event
    {
        public Supplier Supplier { get; set; }

        public CreateCustomerEvent(Supplier supplier)
        {
            Supplier = supplier;
        }
    }
}
