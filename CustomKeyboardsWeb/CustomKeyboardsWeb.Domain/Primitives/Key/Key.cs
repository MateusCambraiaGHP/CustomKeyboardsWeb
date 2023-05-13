using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Key : AggregateRoot
    {
        private Key() { }

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

        public Name Name { get; set; }
        public Price Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
