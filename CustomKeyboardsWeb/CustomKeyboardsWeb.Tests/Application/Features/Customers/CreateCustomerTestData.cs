using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Tests.Application.Shared;

namespace CustomKeyboardsWeb.Tests.Application.Features.Customers
{
    public class CreateCustomerTestData : BaseTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { CreateCustomer_Sucess() };
        }

        private static BaseTestData CreateCustomer_Sucess() 
        {
            return new CreateCustomerTestData()
            {
                ExpectedSucess = true,
                CommandDto = new CustomerDto
                {
                    Name = "TesteCreate",
                    FantasyName = "TesteCreate",
                    Cep = "TesteCreate",
                    Address = "TesteCreate",
                    FederativeUnit = "MG",
                    Phone = "31997876723",
                    Active = "1"
                }
            };
        }
    }
}
