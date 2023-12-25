using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Keys
{
    public class Key : AggregateRoot
    {
        public Name Name { get; private set; }
        public Price Price { get; private set; }

        protected Key() { }

        private Key(
            Name name,
            Price price,
            string active)
        {
            Name = name;
            Price = price;
            Active = active;
        }

        public static Key Create(
            Name name,
            Price price,
            string active)
        {
            return new Key(
                name,
                price,
                active);
        }
    }
}
