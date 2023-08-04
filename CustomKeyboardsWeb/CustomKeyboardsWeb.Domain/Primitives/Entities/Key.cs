using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class Key : AggregateRoot
    {
        public Name Name { get; private set; }
        public Price Price { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected Key() { }

        private Key(
            Name name,
            Price price,
            string active,
            string createdBy,
            DateTime createdAt,
            string? updatedBy,
            DateTime? updatedAt)
        {
            Name = name;
            Price = price;
            Active = active;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
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
                DateTime.UtcNow,
                null,
                null);
        }
    }
}
