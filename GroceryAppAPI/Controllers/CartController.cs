using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using System.Collections.Generic;
using System;

namespace GroceryAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartAccessor _cartAccessor;

        public CartsController()
        {
            _cartAccessor = new CartAccessor(); 
        }

        [HttpGet]
        public IActionResult GetAllCarts()
        {
            try
            {
                IEnumerable<Cart> carts = _cartAccessor.GetAllCarts();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{cartId}")]
        public IActionResult GetCartByCartId(int cartId)
        {
            try
            {
                Cart cart = _cartAccessor.GetCartByCartId(cartId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetCartByUserId(int userId)
        {
            try
            {
                Cart cart = _cartAccessor.GetCartByUserId(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
