using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;

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
                var carts = _cartAccessor.GetAllCarts();
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
                var cart = _cartAccessor.GetCartByCartId(cartId);
                if (cart == null)
                    return NotFound($"Cart with ID {cartId} not found");

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
                var cart = _cartAccessor.GetCartByUserId(userId);
                if (cart == null)
                    return NotFound($"Cart for user ID {userId} not found");

                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("user/{userId}/product/{productId}")]
        public IActionResult AddToCart(int userId, int productId, [FromQuery] int quantity = 1)
        {
            try
            {
                Cart cart;
                try
                {
                    cart = _cartAccessor.GetCartByUserId(userId);
                }
                catch
                {
                    const string createCartQuery = "INSERT INTO Carts (UserID) VALUES (@UserID)";
                    var createParams = new List<SqlParameter>
                    {
                        new SqlParameter("@UserID", userId)
                    };
                    DatabaseAccessor.ExecuteNonQuery(createCartQuery, createParams);

                    cart = _cartAccessor.GetCartByUserId(userId);
                }

                const string updateQuery = @"
                    IF EXISTS (SELECT 1 FROM CartProducts WHERE CartID = @CartID AND ProductID = @ProductID)
                        UPDATE CartProducts SET Quantity = Quantity + @Quantity 
                        WHERE CartID = @CartID AND ProductID = @ProductID
                    ELSE
                        INSERT INTO CartProducts (CartID, ProductID, Quantity) 
                        VALUES (@CartID, @ProductID, @Quantity)";

                var updateParams = new List<SqlParameter>
                {
                    new SqlParameter("@CartID", cart.CartId),
                    new SqlParameter("@ProductID", productId),
                    new SqlParameter("@Quantity", quantity)
                };

                DatabaseAccessor.ExecuteNonQuery(updateQuery, updateParams);

                cart = _cartAccessor.GetCartByUserId(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{cartId}/product/{productId}")]
        public IActionResult RemoveFromCart(int cartId, int productId)
        {
            try
            {
                const string deleteQuery = "DELETE FROM CartProducts WHERE CartID = @CartID AND ProductID = @ProductID";
                var deleteParams = new List<SqlParameter>
                {
                    new SqlParameter("@CartID", cartId),
                    new SqlParameter("@ProductID", productId)
                };

                var result = DatabaseAccessor.ExecuteNonQuery(deleteQuery, deleteParams);
                if (result == 0)
                {
                    return NotFound($"Product {productId} not found in cart {cartId}");
                }

                // Get updated cart
                var cart = _cartAccessor.GetCartByCartId(cartId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
