using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class Customer : AggregateRoot
    {
        public Name Name { get; private set; } = null!;
        public FantasyName FantasyName { get; private set; } = null!;
        public Cep Cep { get; private set; } = null!;
        public Address Address { get; private set; } = null!;
        public FederativeUnit FederativeUnit { get; private set; } = null!;
        public Phone? Phone { get; private set; }
        public string CreatedBy { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
      
        private Customer() { }

        private Customer(
            Name name,
            FantasyName fantasyName,
            Cep cep,
            Address address,
            FederativeUnit federativeUnit,
            Phone? phone,
            string active,
            string createdBy,
            DateTime createdAt,
            string? updatedBy,
            DateTime? updatedAt)
        {
            Name = name;
            FantasyName = fantasyName;
            Cep = cep;
            Address = address;
            FederativeUnit = federativeUnit;
            Phone = phone;
            Active = active;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
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
                active,
                "Administrator",
                DateTime.UtcNow,
                null,
                null);
        }
    }
}
