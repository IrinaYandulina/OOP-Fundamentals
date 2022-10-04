using ACM.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BLTest
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void RetrieveValid() // void, т к не ожидаем никакого результата, т к в тестах не имеет смысла возвращать результат
        {
            //-- Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1) // проверяем, как запишется в список кастомер
            {
                EmailAddress = "fbaggins@gmail.com",
                FirstName = "Frodo",
                LastName = "Baggins"

            };
            //-- Act 
            var actual = customerRepository.Retrieve(1); 
            //-- Assert
            Assert.Equal(expected.CustomerID, actual.CustomerID);
            Assert.Equal(expected.EmailAddress, actual.EmailAddress);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }

        [Fact]
        public void RetrieveExistingWithAddresses()
        {
            //-- Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1) //создаем фейкового кастомера
            {
                EmailAddress = "fbaggins@gmail.com",// прописываем характеристики фейкового кастомера
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>
                {
                    new Address(1) // пишем фейковые адреса
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot now",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144"
                    },
                    new Address(2)
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        StreetLine2 = "Bagshot now",
                        City = "Bywater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146"
                    }
                }
            };

            //-- Act 
            var actual = customerRepository.Retrieve(1); // получаем из базы данных кастомера с id=1
            //-- Assert
            Assert.Equal(expected.CustomerID, actual.CustomerID);
            Assert.Equal(expected.EmailAddress, actual.EmailAddress);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);

            for (int i = 0; i < expected.AddressList.Count; i++)
            {
                Assert.Equal(expected.AddressList[i].AddressType, actual.AddressList[i].AddressType);
                Assert.Equal(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
            }
        }
    }
}
