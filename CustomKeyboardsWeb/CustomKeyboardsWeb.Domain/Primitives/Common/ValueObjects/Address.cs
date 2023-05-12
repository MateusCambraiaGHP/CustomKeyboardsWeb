using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public sealed class Address : ValueObject
    {

#pragma warning disable CS8618
        private Address()
        {
        }
#pragma warning restore CS8618

        private Address(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static Address Create(string adress)
        {
            return new Address(adress);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
