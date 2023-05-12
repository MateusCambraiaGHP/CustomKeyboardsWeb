namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Price : ValueObject
    {
        private Price() { }

        public Price(double value)
        {
            Value = value;
        }

        public double Value { get; }

        public static Price Create(double price)
        {
            return new Price(price);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
