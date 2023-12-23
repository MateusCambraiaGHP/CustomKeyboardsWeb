namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email() { }
        public Email(string value) => Value = value;

        public static Email Create(string name) => new Email(name);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
