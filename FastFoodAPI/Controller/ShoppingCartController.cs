using FastFoodHouse_API.Data;
using FastFoodHouse_API.Models;
using FastFoodHouse_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodHouse_API.Controller
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        private readonly ApiResponse _response;
        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ApiResponse();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetShoppingCarts(string id)
        {
            ShoppingCart? shoppingCart;
            if(string.IsNullOrEmpty(id)) 
            {
                shoppingCart = new();
            }
            else
            {
                 shoppingCart = await _db.ShoppingCarts
                .Include(u => u.CartItems).ThenInclude(u => u.MenuItem)
                .FirstOrDefaultAsync(u => u.UserId == id);
            }
            if(shoppingCart.CartItems != null && shoppingCart.CartItems.Count > 0)
            {

            }
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            _response.Result = shoppingCart;
            return Ok(_response);

        }


        [HttpPost]

        public async Task<ActionResult<ApiResponse>> AddshoppingCartAndItem(string userId, int menuItemId, int updateQuantity)
        {
            ShoppingCart? shoppingCart = _db.ShoppingCarts.Include(u => u.CartItems).FirstOrDefault(u => u.UserId == userId);
            MenuItem? menuItem = _db.Menu.FirstOrDefault(u => u.Id == menuItemId);
            if (menuItem == null) 
            {
                _response.StatusCode=System.Net.HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return Ok(_response);
            }
            if(shoppingCart == null) 
            {
                ShoppingCart newCart = new() { UserId = userId };
                _db.Add(newCart);
                await _db.SaveChangesAsync();

                CartItem newCartItem = new CartItem()
                {
                    Quantity = updateQuantity,
                    MenuItemId = menuItem.Id,
                    ShoppingCartId = newCart.id
                   
                };
                _db.Add(newCartItem);
                await _db.SaveChangesAsync();
            }
            return Ok(_response);
        }
    }
}
