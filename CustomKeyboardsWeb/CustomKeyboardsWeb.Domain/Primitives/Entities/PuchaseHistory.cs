using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class PuchaseHistory : AggregateRoot
    {
        public int IdCustomer { get; private set; }
        public int IdSupplier { get; private set; }
        public int IdKeyboard { get; private set; }
        public Customer? Customer { get; private set; }
        public Supplier? Supplier { get; private set; }
        public Keyboard? Keyboard { get; private set; }
        public Price Price { get; private set; }
        public DateTime PuchaseDate { get; private set; }

        private PuchaseHistory() { }

        private PuchaseHistory(
            int idCustomer,
            int idSupplier,
            int idKeyboard,
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
            int idCustomer,
            int idSupplier,
            int idKeyboard,
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
