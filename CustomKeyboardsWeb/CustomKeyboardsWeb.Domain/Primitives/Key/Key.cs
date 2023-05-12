using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Key : AggregateRoot
    {
        public Name Name { get; set; }
        public Price Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
