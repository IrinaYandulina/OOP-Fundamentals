using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    { /// <summary>
      /// Retrieve one product.
      /// </summary>>
      /// <returns></returns>>
        public Product Retrieve(int productId)
        {
            // Code that retrieves the defined product 
            return new Product();
        }

        /// <summary>
        /// Saves the current product.
        /// </summary>>
        /// <returns></returns>>
        public bool Save(Product product)
        {
            // Code that saves the defined product
            var success = true;

            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {
                        // call insert database procedutr
                    }
                    else
                    {
                        // call update database repoitory
                    }
                }
                else
                {

                }
            }
            return true;
        }
    }
}
