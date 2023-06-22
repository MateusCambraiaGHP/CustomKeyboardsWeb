namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Color : ValueObject
    {
        protected Color() { }

        public Color(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Color Create(string color)
        {
            return new Color(color);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
