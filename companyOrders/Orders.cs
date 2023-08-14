using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyOrders
{
    public class Order
    {
        public int idx { get; set; }
        public char Tip { get; set; }
        public int PartiNo { get; set; }
        public int Quantity { get; set; }
        public int Kalan { get; set; }
        public int Price { get; set; }
    }
}
