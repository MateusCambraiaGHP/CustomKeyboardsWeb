using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Supplier : AggregateRoot
    {
        private Supplier() { }

        private Supplier(
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

        public static Supplier Create(
            Name name,
            FantasyName fantasyName,
            Cep cep,
            Address address,
            FederativeUnit federativeUnit,
            Phone? phone,
            string active) 
        {
            return new Supplier(
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

        public Name Name { get; set; }
        public FantasyName FantasyName { get; set; }
        public Cep Cep { get; set; }
        public Address Address { get; set; }
        public FederativeUnit FederativeUnit { get; set; }
        public Phone? Phone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
