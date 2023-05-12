using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;

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
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
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
