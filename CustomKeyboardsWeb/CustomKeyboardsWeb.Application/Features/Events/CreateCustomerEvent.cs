using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

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
