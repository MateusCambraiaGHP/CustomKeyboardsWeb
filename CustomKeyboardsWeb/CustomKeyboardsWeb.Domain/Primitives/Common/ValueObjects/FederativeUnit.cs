namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class FederativeUnit : ValueObject
    {
        public string Value { get; }

        private FederativeUnit() { }
        public FederativeUnit(string value) => Value = value;

        public static FederativeUnit Create(string federativeUnit) => new FederativeUnit(federativeUnit);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
