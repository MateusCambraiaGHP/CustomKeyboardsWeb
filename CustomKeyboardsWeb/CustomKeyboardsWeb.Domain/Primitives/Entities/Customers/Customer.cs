using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Customers
{
    public class Customer : AggregateRoot
    {
        public Name Name { get; private set; } = null!;
        public FantasyName FantasyName { get; private set; } = null!;
        public Cep Cep { get; private set; } = null!;
        public Address Address { get; private set; } = null!;
        public FederativeUnit FederativeUnit { get; private set; } = null!;
        public Phone? Phone { get; private set; }

        private Customer() { }

        private Customer(
            Name name,
            FantasyName fantasyName,
            Cep cep,
            Address address,
            FederativeUnit federativeUnit,
            Phone? phone,
            string active)
        {
            Name = name;
            FantasyName = fantasyName;
            Cep = cep;
            Address = address;
            FederativeUnit = federativeUnit;
            Phone = phone;
            Active = active;
        }

        public static Customer Create(
            Name name,
            FantasyName fantasyName,
            Cep cep,
            Address address,
            FederativeUnit federativeUnit,
            Phone? phone,
            string active)
        {
            return new Customer(
                name,
                fantasyName,
                cep,
                address,
                federativeUnit,
                phone,
                active);
        }
    }
}
