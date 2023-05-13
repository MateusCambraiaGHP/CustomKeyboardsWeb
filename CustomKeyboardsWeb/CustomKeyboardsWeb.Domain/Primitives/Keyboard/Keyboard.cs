using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Keyboard : AggregateRoot
    {
        private Keyboard() { }

        private Keyboard(
            Name name,
            int? idSwitch,
            int? idKey,
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
            int? idSwitch,
            int? idKey,
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

        public Name Name { get; set; }
        public int? IdSwitch { get; set; }
        public int? IdKey { get; set; }
        public Price Price { get; set; }
        public Switch Switch { get; set; }
        public Key Key { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
