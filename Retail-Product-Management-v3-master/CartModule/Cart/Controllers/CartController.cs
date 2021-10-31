using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cart.Model;
using Cart.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CartController : ControllerBase
    {
        Uri baseAddress = new Uri("https://localhost:44359");
        HttpClient client;
        ICartItemRepo icart;
        public CartController(ICartItemRepo _db)
        {
            icart = _db;
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            if ((icart.GetCartItem(username)).Count == 0)
            {
                return BadRequest("No vendor");
            }
            return Ok(icart.GetCartItem(username));
        }
        [HttpGet("LoadCartDetailsByUserName/{userName}")]
        public List<CartItem> LoadCartDetailsByUserName(string userName)
        {
            List<CartItem> cartItems = icart.LoadCartDetailsByUserName(userName);
            return cartItems;

        }
        [HttpPost]
        public List<CartItem> Post([FromBody] CartRequestModel obj)
        {
          List<CartItem> cartItems=  icart.AddItemsToCart(obj);
            return cartItems;
        }

        //[HttpPost("{username}")]
        //public IActionResult Post(string username, [FromBody] ProductItem obj)
        //{
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/vendor/"+obj.Id).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = JsonConvert.SerializeObject(response);
        //        VendorDetail vendor = JsonConvert.DeserializeObject<VendorDetail>(data);
        //        CartItemRepo cartrepo = new CartItemRepo();
        //        if (cartrepo.PostCartItem(username, obj, vendor))
        //            return Ok();
        //        return BadRequest();                
        //    }
        //    return BadRequest();
        //}

        [HttpGet("DeleteCartDetails/{id}")]
        public List<CartItem> Delete(int id)
        {
            return icart.DeleteDetail(id);
        }
    }
}
