﻿namespace CustomKeyboardsWeb.Application.Dtos.Switchies
{
    public class UpdateSwitchDto
    {
        public Guid Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public double Price { get; set; }
    }
}
