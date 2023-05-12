using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Cep : ValueObject
    {
        private Cep() { }

        public Cep(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Cep Create(string cep)
        {
            return new Cep(cep);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
