using Cart.Model;
using System.Collections.Generic;

namespace Cart.Repository
{
    public interface ICartItemRepo
    {
        List<CartItem> GetCartItem(string username);
        bool PostCartItem(string username ,ProductItem pitem, VendorDetail vdetail);
        List<CartItem> DeleteDetail(int Id);
        CartItem GetDetailbyId(int Id);
        List<CartItem> AddItemsToCart(CartRequestModel obj);
        List<CartItem> LoadCartDetailsByUserName(string userName);
    }
}