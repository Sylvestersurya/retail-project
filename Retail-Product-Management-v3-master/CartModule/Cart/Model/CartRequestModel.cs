using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Model
{
    public class CartRequestModel
    {
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public string UserName { get; set; }
    }
}
