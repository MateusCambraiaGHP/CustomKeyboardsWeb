using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards
{
    public class Keyboard : AggregateRoot
    {
        public Name Name { get; private set; }
        public Guid? IdSwitch { get; private set; }
        public Guid? IdKey { get; private set; }
        public Price Price { get; private set; }
        public Switch Switch { get; private set; }
        public Key Key { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        private Keyboard() { }

        private Keyboard(
            Name name,
            Guid? idSwitch,
            Guid? idKey,
            Price price,
            string active)
        {
            Name = name;
            IdSwitch = idSwitch;
            IdKey = idKey;
            Price = price;
            Active = active;
            ValidationResult = Validate();
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
                active);
        }

        private ValidationResult Validate() => new KeyboardValidator().Validate(this);
    }
}
