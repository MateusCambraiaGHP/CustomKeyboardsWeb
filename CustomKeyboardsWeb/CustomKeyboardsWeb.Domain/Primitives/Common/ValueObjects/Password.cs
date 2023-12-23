namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; }

        private Password() { }
        public Password(string value) => Value = value;

        public static Password Create(string name) => new Password(name);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
