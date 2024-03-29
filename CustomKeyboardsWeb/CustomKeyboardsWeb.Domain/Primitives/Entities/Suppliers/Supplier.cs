﻿using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers
{
    public class Supplier : AggregateRoot
    {
        public Name Name { get; private set; }
        public FantasyName FantasyName { get; private set; }
        public Cep Cep { get; private set; }
        public Address Address { get; private set; }
        public FederativeUnit FederativeUnit { get; private set; }
        public Phone? Phone { get; private set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

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
            string? updatedBy)
        {
            Name = name;
            FantasyName = fantasyName;
            Cep = cep;
            Address = address;
            FederativeUnit = federativeUnit;
            Phone = phone;
            Active = active;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
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
                null);
        }
    }
}
