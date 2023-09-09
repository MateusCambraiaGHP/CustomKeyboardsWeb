namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Name : ValueObject
    {
        private Name() { }

        public Name(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Name Create(string name)
        {
            return new Name(name);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
