namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; }

        private Name() { }
        public Name(string value) => Value = value;

        public static Name Create(string name) => new Name(name);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
