namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class FantasyName : ValueObject
    {
        private FantasyName() { }

        public FantasyName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static FantasyName Create(string fantasyName)
        {
            return new FantasyName(fantasyName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
