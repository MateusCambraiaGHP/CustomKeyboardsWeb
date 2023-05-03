using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public class Keyboard : Entity
    {
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public int? IdSwitch { get; set; }
        public int? IdKey { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public double Price { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
