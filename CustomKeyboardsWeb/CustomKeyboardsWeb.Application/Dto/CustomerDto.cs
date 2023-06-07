namespace CustomKeyboardsWeb.Application.Dto
{
    public class CustomerDto 
    {
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Address { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
        public string CreatedBy { get; set; } = "Administrator";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
