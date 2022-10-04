using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order : EntityBase, ILoggable 
    {
        public Order()
        {

        }
        public Order(int orderID)
        {
            OrderID = orderID;
        }

        public int CustomerId { get; set; } // тип зависимости "композиция" 
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int ShippingAddressId { get; set; }

        public string Log()
        {
            var logString = OrderID + ": " +
             "Date: " + OrderDate.Value.Date + " " +
             "Status: " + EntityState.ToString();
            return logString;
        }

        /// <summary>
        /// Validates the order data.
        /// </summary>>
        /// <returns></returns>>
        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid;
        }
    }
}
