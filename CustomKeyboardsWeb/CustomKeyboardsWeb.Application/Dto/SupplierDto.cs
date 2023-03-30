﻿using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Dto
{
    public class SupplierDto
    {
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? FantasyName { get; set; }
        [Required]
        public string? Cep { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? FederativeUnit { get; set; }
        [Required]
        public string? Phone { get; set; }
    }
}
