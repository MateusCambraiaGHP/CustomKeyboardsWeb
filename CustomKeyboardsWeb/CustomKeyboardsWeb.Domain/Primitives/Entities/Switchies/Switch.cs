using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies
{
    public class Switch : AggregateRoot
    {
        public Name Name { get; private set; }
        public Color Color { get; private set; }
        public Price Price { get; private set; }

        private Switch() { }

        private Switch(
            Name name,
            Color color,
            Price price,
            string active)
        {
            Name = name;
            Color = color;
            Price = price;
            Active = active;
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
                active);
        }
    }
}
