using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class PuchaseHistory : AggregateRoot
    {
        public Guid IdCustomer { get; private set; }
        public Guid IdSupplier { get; private set; }
        public Guid IdKeyboard { get; private set; }
        public Customer? Customer { get; private set; }
        public Supplier? Supplier { get; private set; }
        public Keyboard? Keyboard { get; private set; }
        public Price Price { get; private set; }
        public DateTime PuchaseDate { get; private set; }

        private PuchaseHistory() { }

        private PuchaseHistory(
            Guid idCustomer,
            Guid idSupplier,
            Guid idKeyboard,
            Price price,
            string active,
            DateTime puchaseDate)
        {
            IdCustomer = idCustomer;
            IdSupplier = idSupplier;
            IdKeyboard = idKeyboard;
            Price = price;
            Active = active;
            PuchaseDate = puchaseDate;
        }

        public static PuchaseHistory Create(
            Guid idCustomer,
            Guid idSupplier,
            Guid idKeyboard,
            Price price,
            string active)
        {
            return new PuchaseHistory(
                idCustomer,
                idSupplier,
                idKeyboard,
                price,
                active,
                DateTime.UtcNow);
        }
    }
}
