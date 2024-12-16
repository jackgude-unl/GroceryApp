using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using Managers.Interfaces;
using Engines;
using Engines.Interfaces;
using Managers;
using System;
using System.Collections.Generic;

namespace GroceryAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductAccessor _productAccessor;
        private readonly ProductEngine _productengine;
        private readonly ProductManager _productmanager;

        public ProductsController()
        {
            _productAccessor = new ProductAccessor();
            _productengine = new ProductEngine();
            _productmanager = new ProductManager(_productAccessor, _productengine);
        }

        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] string search = null)
        {
            try
            {
                IEnumerable<Product> products = _productmanager.SearchBar(search);
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
                // This might happen if no rows are returned (depending on how GetProductById is implemented)
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
                // If no products found for the category, it's not necessarily an error, just return empty array
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
