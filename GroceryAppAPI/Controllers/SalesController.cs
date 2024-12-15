using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using System;

namespace GroceryAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleAccessor _saleAccessor;

        public SalesController(ISaleAccessor saleAccessor)
        {
            _saleAccessor = saleAccessor;
        }

        [HttpGet("current")]
        public IActionResult GetCurrentSale()
        {
            try
            {
                Sale sale = _saleAccessor.GetCurrentSale();
                if (sale == null)
                {
                    return NotFound(new { error = "No current sale found." });
                }
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
