using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class Keyboard : AggregateRoot
    {
        public Name Name { get; private set; }
        public Guid? IdSwitch { get; private set; }
        public Guid? IdKey { get; private set; }
        public Price Price { get; private set; }
        public Switch Switch { get; private set; }
        public Key Key { get; private set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        private Keyboard() { }

        private Keyboard(
            Name name,
            Guid? idSwitch,
            Guid? idKey,
            Price price,
            string active,
            string createdBy,
            DateTime createdAt,
            string? updatedBy,
            DateTime? updatedAt)
        {
            Name = name;
            IdSwitch = idSwitch;
            IdKey = idKey;
            Price = price;
            Active = active;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }

        public static Keyboard Create(
            Name name,
            Guid? idSwitch,
            Guid? idKey,
            Price price,
            string active)
        {
            return new Keyboard(
                name,
                idSwitch,
                idKey,
                price,
                active,
                "Administrator",
                DateTime.UtcNow,
                null,
                null);
        }
    }
}
