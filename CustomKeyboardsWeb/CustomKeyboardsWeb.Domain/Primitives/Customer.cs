using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives
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
        public string? Phone { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
