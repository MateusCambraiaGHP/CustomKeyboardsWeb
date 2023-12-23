namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Color : ValueObject
    {
        public string Value { get; }

        protected Color() { }
        public Color(string value) => Value = value;

        public static Color Create(string color) => new Color(color);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
