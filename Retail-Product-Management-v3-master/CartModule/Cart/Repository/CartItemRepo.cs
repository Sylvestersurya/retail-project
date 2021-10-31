using Cart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Repository
{
    public class CartItemRepo : ICartItemRepo
    {
        int i = 1;
        public static List<CartItem> cartlist = new List<CartItem>();
        public static List<VendorStock> vendorsproduct = new List<VendorStock>
        {
            new VendorStock{ProductId = 1, VendertId= 1, StockInHand = 0 , DeliveryDate = DateTime.Parse("10-10-2020")},
            new VendorStock{ProductId = 2, VendertId= 2, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-11-2020")},
            new VendorStock{ProductId = 3, VendertId= 3, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-12-2020")},
            new VendorStock{ProductId = 4, VendertId= 4, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-13-2020")},
            new VendorStock{ProductId = 5, VendertId= 5, StockInHand = 50 , DeliveryDate = DateTime.Parse("10-14-2020")}

        };
        public static List<VendorDetail> vendors = new List<VendorDetail>
        {
            new VendorDetail{Id=1,Name="Cloud Retail",Rating=5,DeliveryCharge=80 },
            new VendorDetail{Id=2,Name="SSK Retail",Rating=5,DeliveryCharge=40 },
            new VendorDetail{Id=3,Name="ABB Retail",Rating=3,DeliveryCharge=60 },
            new VendorDetail{Id=4,Name="REL Retail",Rating=3,DeliveryCharge=70 },
            new VendorDetail{Id=5,Name="MFF Retail",Rating=5,DeliveryCharge=76 }
        };
        public static List<ProductItem> products = new List<ProductItem> {
            new ProductItem{Id=1,Name="Mobile",Description="Android phone",Price=10999,Rating=5,Image_name="Mob.jpg",IsAvailable=true},
            new ProductItem{Id=2,Name="Laptop",Description="Lenovo, 8GB, 1TB",Price=45000,Rating=4,Image_name="Lap.jpg",IsAvailable=true},
            new ProductItem{Id=3,Name="Desktop",Description="HP Brand",Price=25000,Rating=4,Image_name="des.jpg",IsAvailable=false},
            new ProductItem{Id=4,Name="AC",Description="Voltas , 1.5 Top",Price=32000,Rating=5,Image_name="ac.jpg",IsAvailable=true},
            new ProductItem{Id=5,Name="Heater",Description="Prestige, 1KW",Price=1400,Rating=4,Image_name="heater.jpg",IsAvailable=false}
        };

        public CartItem GetDetailbyId(int Id)
        {
            return (cartlist.Where(x => x.Id == Id)).FirstOrDefault();
        }

        public List<CartItem> GetCartItem(string username)
        {
            List<CartItem> ls = new List<CartItem>();
            foreach (CartItem c in cartlist)
            {
                if (c.UserName == username)
                {
                    ls.Add(c);
                }
            }
            return ls;
        }
        public List<CartItem> AddItemsToCart(CartRequestModel obj)
        {
            CartItem cartItem = (from e in vendorsproduct
                                 join v in vendors on e.VendertId equals v.Id
                                 join p in products on e.ProductId equals p.Id
                                 where e.ProductId == obj.ProductId && e.VendertId == obj.VendorId
                                 select new CartItem()
                                 {
                                  Id=p.Id,
                                  DeliveryCharge=v.DeliveryCharge,
                                  DeliveryDate=e.DeliveryDate,
                                  Description=p.Description,
                                  Price=p.Price,
                                  ProductName=p.Name,
                                  UserName=obj.UserName,
                                  VendorName=v.Name
                                 }).FirstOrDefault();
            cartlist.Add(cartItem);
            return cartlist.Where(e=>e.UserName==obj.UserName).ToList();
        }
        public bool PostCartItem(string username, ProductItem pitem, VendorDetail vdetail)
        {
            CartItem cItem = new CartItem();
            cItem.UserName = username;
            cItem.ProductName = pitem.Name;
            cItem.Price = pitem.Price;
            cItem.Description = pitem.Description;
            cItem.VendorName = vdetail.Name;
            cItem.DeliveryCharge = vdetail.DeliveryCharge;
            //date has been taken by default as vendor does not return date as discribed in document......
            cItem.DeliveryDate = DateTime.Parse("12-10-2020");

            if (pitem.IsAvailable==false)
            {
                cartlist.Add(cItem);
                return true;
            }
            return false;
        }

        public List<CartItem> DeleteDetail(int Id)
        {
            CartItem cartItem = cartlist.Where(x => x.Id == Id).FirstOrDefault();
            List<CartItem> objList = (cartlist.Where(x => x.Id != Id)).ToList();
            cartlist.Remove(cartItem);
            return objList;
        }
        public List<CartItem> LoadCartDetailsByUserName(string userName)
        {
            return cartlist.Where(e => e.UserName == userName).ToList();
        }

    }
}
