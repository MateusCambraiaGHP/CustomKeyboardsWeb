﻿namespace CustomKeyboardsWeb.Application.Features.ViewModel.Keys
{
    public class KeyViewModel
    {
        public Guid? Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public DateTime InsertionDate { get; protected set; }
        public DateTime LastModification { get; protected set; }
    }
}
