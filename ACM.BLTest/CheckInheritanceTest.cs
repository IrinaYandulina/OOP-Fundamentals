using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BLTest
{
    public class CheckInheritanceTest
    {
        [Fact]
        public void CheckProductOverriding()
        {
            Object myObject = new Object();
            Product product = new Product();
            product.ProductName = "cup of tea";

            Assert.Equal("System.Object", myObject.ToString());
            Assert.Equal("cup of tea", product.ToString());
        }
    }
}
