using Accessors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.Classes
{
    public class Cart : ICart
    {
        public string CartId { get; }
        public string UserId { get; }
        public IEnumerable<Product> ProductsInCart { get; }

        public Cart(string cartId, string userId, IEnumerable<Product> productsInCart)
        {
            CartId = cartId;
            UserId = userId;
            ProductsInCart = productsInCart;
        }

        public bool AddProduct(Product product)
        {
            return false;
        }

        public bool RemoveProduct(Product product)
        {
            return false;
        }

        public double CalculateTotal()
        {
            return 0;
        }
    }

    public class CartAccessor : ICartAccessor
    {
        public IEnumerable<Cart> GetAllCarts()
        {
            return null;
        }

        public Cart GetCartByCartId(int id)
        {
            return null;
        }

        public Cart GetCartByUserId(int id)
        {
            return null;
        }
    }
}
