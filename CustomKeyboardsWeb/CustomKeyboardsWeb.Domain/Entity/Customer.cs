using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Entity
{
    public class Customer : Entity
    {
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string FantasyName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Cep { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Adress { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string FederativeUnit { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }
    }
}
