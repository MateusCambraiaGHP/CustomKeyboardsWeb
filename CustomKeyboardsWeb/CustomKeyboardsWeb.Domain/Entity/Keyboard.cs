using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public class Keyboard
    {
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public int IdSwitch { get; set; }
        public int IdKey { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public double Price { get; set; }
    }
}
