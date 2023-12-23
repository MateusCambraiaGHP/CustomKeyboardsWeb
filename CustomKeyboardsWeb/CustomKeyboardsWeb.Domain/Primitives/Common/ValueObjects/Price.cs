namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Price : ValueObject
    {
        public double Value { get; }

        private Price() { }
        public Price(double value) => Value = value;

        public static Price Create(double price) => new Price(price);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
