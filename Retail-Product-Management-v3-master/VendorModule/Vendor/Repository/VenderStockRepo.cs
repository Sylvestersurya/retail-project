using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendor.Model;

namespace Vendor.Repository
{
    public class VenderStockRepo
    {
        public static List<VendorStock> vendorsproduct = new List<VendorStock>
        {
            new VendorStock{ProductId = 1, VendertId= 1, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-10-2021")},
            new VendorStock{ProductId = 2, VendertId= 2, StockInHand = 0 , DeliveryDate = DateTime.Parse("10-11-2021")},
            new VendorStock{ProductId = 3, VendertId= 3, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-12-2021")},
            new VendorStock{ProductId = 4, VendertId= 4, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-13-2021")},
            new VendorStock{ProductId = 5, VendertId= 5, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-14-2021")}

        };
        public static List<VendorDetail> vendors = new List<VendorDetail>
        {
            new VendorDetail{Id=1,Name="Cloud Retail",Rating=5,DeliveryCharge=80 },
            new VendorDetail{Id=2,Name="SSK Retail",Rating=5,DeliveryCharge=40 },
            new VendorDetail{Id=3,Name="ABB Retail",Rating=3,DeliveryCharge=60 },
            new VendorDetail{Id=4,Name="REL Retail",Rating=3,DeliveryCharge=70 },
            new VendorDetail{Id=5,Name="MFF Retail",Rating=5,DeliveryCharge=76 }
        };

        public List<VendorStockDetails> GetVendorbyId(int ProductId)
        {
            List<VendorStockDetails> vendorStockDetails=(from e in vendorsproduct
                                                        join vd in vendors on e.VendertId equals vd.Id
                                                        where e.ProductId == ProductId
                                                        select new VendorStockDetails(){
                                                            VendorId=vd.Id,
                                                            VendorName=vd.Name,
                                                            StockInHand=e.StockInHand,
                                                            DeliveryDate=e.DeliveryDate,
                                                            Rating=vd.Rating,
                                                            DeliveryCharge=vd.DeliveryCharge,
                                                            ProductId=e.ProductId
                                                        }).ToList();
            //List<int> ls = new List<int>();
            //foreach(VendorStock v in vendorsproduct)
            //{
            //    if(v.ProductId == ProductId && v.StockInHand > 1)
            //    {
            //        ls.Add(v.VendertId);
            //    }
            //}
            //return ls;
            return vendorStockDetails;
        }
    }
}
