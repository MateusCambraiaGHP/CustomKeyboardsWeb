using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class PuchaseHistory : AggregateRoot
    {
        public int IdCustomer { get; set; }
        public int IdSupplier { get; set; }
        public int IdKeyboard { get; set; }
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public Keyboard Keyboard { get; set; }
        public Price Price { get; set; }
        public DateTime PuchaseDate { get; set; }
    }
}
