using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Customer : AggregateRoot
    {
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

        public Name Name { get; set; } = null!;
        public FantasyName FantasyName { get; set; } = null!;
        public Cep Cep { get; set; } = null!;
        public Address Address { get; private set; } = null!;
        public FederativeUnit FederativeUnit { get; set; } = null!;
        public Phone? Phone { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
