namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Phone : ValueObject
    {
        public string Value { get; }

        private Phone() { }
        public Phone(string value) => Value = value;

        public static Phone Create(string phone) => new Phone(phone);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
