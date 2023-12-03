﻿namespace CustomKeyboardsWeb.Application.Dtos.Suppliers
{
    public class UpdateSupplierDto
    {
        public Guid Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Adress { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
    }
}
