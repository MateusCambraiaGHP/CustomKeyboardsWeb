using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public  abstract class Entity
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string Active { get; set; }
    }
}
