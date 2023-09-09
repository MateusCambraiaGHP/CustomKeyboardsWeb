namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Password : ValueObject
    {
        private Password() { }

        public Password(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Password Create(string name)
        {
            return new Password(name);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
