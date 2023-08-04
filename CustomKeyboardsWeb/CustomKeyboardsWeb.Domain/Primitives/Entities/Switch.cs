using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class Switch : AggregateRoot
    {
        public Name Name { get; private set; }
        public Color Color { get; private set; }
        public Price Price { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private Switch() { }

        private Switch(
            Name name,
            Color color,
            Price price,
            string active,
            string createdBy,
            DateTime createdAt,
            string? updatedBy,
            DateTime? updatedAt)
        {
            Name = name;
            Color = color;
            Price = price;
            Active = active;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }

        public static Switch Create(
            Name name,
            Color color,
            Price price,
            string active)
        {
            return new Switch(
                name,
                color,
                price,
                active,
                "Administator",
                DateTime.UtcNow,
                null,
                null);
        }
    }
}
