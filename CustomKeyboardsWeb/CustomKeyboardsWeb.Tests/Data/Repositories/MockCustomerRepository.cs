using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using Moq;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Tests.Data.Repositories
{
    public class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetMock()
        {
            var mock = new Mock<ICustomerRepository>();

            mock.Setup(c => c.Create(It.IsAny<Customer>()));
            mock.Setup(customerRepository => customerRepository.GetAsync(null, null, null))
                .ReturnsAsync((Expression<Func<Customer, bool>> filter,
                                Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy,
                                Expression<Func<Customer, object>>[] includes) =>
                {
                    var customers = CustomersMock();
                    var filteredCustomers = customers.ToList();
                    return filteredCustomers;
                });



            return mock;
        }

        private static List<Customer> CustomersMock()
            => new()
            {
                Customer.Create(
                            Name.Create("TesteCreate"),
                            FantasyName.Create("TesteCreate"),
                            Cep.Create("TesteCreate"),
                            Address.Create("TesteCreate"),
                            FederativeUnit.Create("MG"),
                            Phone.Create("31997876723"),
                            "1"),
            };
    }
}
