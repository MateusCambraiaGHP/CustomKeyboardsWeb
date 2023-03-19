using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public class Key : Entity
    {
        [Column(TypeName = "varchar(15)")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public double Price { get; set; }
    }
}
