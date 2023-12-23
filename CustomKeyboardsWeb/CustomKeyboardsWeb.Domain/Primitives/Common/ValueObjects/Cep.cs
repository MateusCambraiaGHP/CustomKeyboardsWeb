namespace CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects
{
    public class Cep : ValueObject
    {
        public string Value { get; }
        
        private Cep() { }
        public Cep(string value) => Value = value;

        public static Cep Create(string cep) => new Cep(cep);

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
