using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public  abstract class Entity
    {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(1)")]
        public string? Active { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }
    }
}
