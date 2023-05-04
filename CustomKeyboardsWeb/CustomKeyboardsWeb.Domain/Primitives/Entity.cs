using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public  abstract class Entity
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string Active { get; set; }
    }
}
