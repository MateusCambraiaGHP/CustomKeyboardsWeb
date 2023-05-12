using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Keyboard : AggregateRoot
    {
        public Name Name { get; set; }
        public int? IdSwitch { get; set; }
        public int? IdKey { get; set; }
        public Price Price { get; set; }
        public Switch Switch { get; set; }
        public Key Key { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
