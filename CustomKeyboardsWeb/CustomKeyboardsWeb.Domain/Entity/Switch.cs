using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public class Switch : Entity
    {
        [Column(TypeName = "varchar(15)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Color { get; set; }
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
