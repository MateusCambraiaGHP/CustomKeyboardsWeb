namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Email : ValueObject
    {
        private Email() { }

        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Email Create(string name)
        {
            return new Email(name);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
