namespace CarShopEcommerceWeb.DTO
{
    public class Temperatura
    {
        public int Id { get; set; }
        public int Temp { get; set; }
        public int FTemp { get { return ConvertToCelcius(Temp); } }
        public int CTemp { get; set; }
        public int Cep { get; set; }
        public int Adress { get; set; }


        private int ConvertToCelcius(int temp){
            return temp + 1;
        }
    }
}
