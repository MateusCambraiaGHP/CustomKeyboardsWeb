namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Phone : ValueObject
    {
        private Phone() { }

        public Phone(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Phone Create(string phone)
        {
            return new Phone(phone);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
