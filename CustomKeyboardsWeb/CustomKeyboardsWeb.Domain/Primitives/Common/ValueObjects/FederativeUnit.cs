namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class FederativeUnit : ValueObject
    {
        private FederativeUnit() { }

        public FederativeUnit(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static FederativeUnit Create(string federativeUnit)
        {
            return new FederativeUnit(federativeUnit);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
