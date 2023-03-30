using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public class PuchaseHistory : Entity
    {
        public int IdCustomer { get; set; }
        public int IdSupplier { get; set; }
        public int IdKeyboard { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public double Price { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PuchaseDate { get; set; }
    }
}
