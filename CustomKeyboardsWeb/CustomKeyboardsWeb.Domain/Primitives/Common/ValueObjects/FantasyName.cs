namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class FantasyName : ValueObject
    {
        public string Value { get; }

        private FantasyName() { }
        public FantasyName(string value) => Value = value;

        public static FantasyName Create(string fantasyName) => new FantasyName(fantasyName);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
