using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class PuchaseHistory : AggregateRoot
    {
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

        public int IdCustomer { get; set; }
        public int IdSupplier { get; set; }
        public int IdKeyboard { get; set; }
        public Customer? Customer { get; set; }
        public Supplier? Supplier { get; set; }
        public Keyboard? Keyboard { get; set; }
        public Price Price { get; set; }
        public DateTime PuchaseDate { get; set; }
    }
}
