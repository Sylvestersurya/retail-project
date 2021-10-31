using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor.Model
{
    public class VendorStockDetails
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int StockInHand { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Rating { get; set; }
        public double DeliveryCharge { get; set; }
        public int ProductId { get; set; }
    }
}
