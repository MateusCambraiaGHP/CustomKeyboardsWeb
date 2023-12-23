namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public string Value { get; private set; }

        private Address() { }
        private Address(string value) => Value = value;

        public static Address Create(string adress) => new Address(adress);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
