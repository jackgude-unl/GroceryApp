using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using System;
using System.Collections.Generic;

namespace GroceryAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAccessor _productAccessor;

        public ProductsController(IProductAccessor productAccessor)
        {
            _productAccessor = productAccessor;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                IEnumerable<Product> products = _productAccessor.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                Product product = _productAccessor.GetProductById(id);
                if (product == null)
                {
                    return NotFound(new { error = "Product not found." });
                }
                return Ok(product);
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound(new { error = "Product not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            try
            {
                IEnumerable<Product> products = _productAccessor.GetProductsByCategoryId(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("sale")]
        public IActionResult GetProductsOnSale()
        {
            try
            {
                IEnumerable<Product> products = _productAccessor.GetProductsOnSale();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
