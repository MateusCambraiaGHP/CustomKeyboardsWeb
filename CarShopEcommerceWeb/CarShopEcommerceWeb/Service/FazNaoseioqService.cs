using CarShopEcommerceWeb.Interfaces;

namespace CarShopEcommerceWeb.Service
{
    public class FazNaoseioqService : IFazNaoseioqService
    {
        public int Calculacelcius(int valor)
        {
            return valor + 20;
        }
    }
}
