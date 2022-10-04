using Acme.Common;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable // наследует параметры класса EntityBase
    {
        public Customer(): this(0) // this один конструктор вызывает другой конструктор
        {
        }
        public Customer(int customerID)
        {
            CustomerID = customerID; // конструктор класса. гарантируем, что у всех объектов будет customer id
            AddressList = new List<Address>(); // создаем пустой список адресов, чтобы не было ошибки при обращении
        }

        public List<Address> AddressList { get; set; } 
        public int CustomerID { get; private set; } // свойство объекта
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string FullName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(LastName))
                    {
                        return LastName + "," + FirstName;
                    }
                    else
                    {
                        return FirstName;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(LastName))
                    {
                        return LastName;
                    }
                    else
                    {
                        throw new Exception("no data");
                    }
                }
            }
        }

        public string LastName { get; set; }

        public static int InstanceCount { get; set; }

        public string Log()
        { 
           var logString = CustomerID + ": " +
                        FullName + "" +
                        "Email: " + EmailAddress + " " +
                        "Status: " + EntityState.ToString();   
            return logString;
        }

        public override string ToString() => FullName;

        /// <summary>
        /// Validates the customer data.
        /// </summary>>
        /// <returns></returns>>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }
    }
}

  

          