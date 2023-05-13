namespace CustomKeyboardsWeb.Application.Dto
{
    public class PuchaseHistoryDto
    {
        public int IdCustomer { get; set; }
        public int IdSupplier { get; set; }
        public int IdKeyboard { get; set; }
        public double Price { get; set; }
        public string Active { get; set; } = null!;
    }
}
