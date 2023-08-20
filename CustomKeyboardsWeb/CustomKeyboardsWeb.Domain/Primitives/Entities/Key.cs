using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class Key : AggregateRoot
    {
        public Name Name { get; private set; }
        public Price Price { get; private set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        protected Key() { }

        private Key(
            Name name,
            Price price,
            string active,
            string createdBy,
            string? updatedBy)
        {
            Name = name;
            Price = price;
            Active = active;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
        }

        public static Key Create(
            Name name,
            Price price,
            string active)
        {
            return new Key(
                name,
                price,
                active,
                "Administrator",
                null);
        }
    }
}
