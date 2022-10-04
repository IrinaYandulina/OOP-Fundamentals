using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }
        public Product(int productID)
        {
            ProductID = productID;
        }
        public decimal? CurrentPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductID { get; set; }

        private string _productName;
        public string ProductName    
        {
            get            
            {
                return _productName.InsertSpaces();
            }
            set
            {
                _productName = value;
            }
        }

        /// <summary>
        /// Validates the product data.
        /// </summary>>
        /// <returns></returns>>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return ProductName;
        }

        public string Log()
        {
            var logString = ProductID + ": " +
                         ProductName + "" +
                         "Detail: " + ProductDescription + " " +
                         "Status: " + EntityState.ToString();
            return logString;
        }
    }
}
