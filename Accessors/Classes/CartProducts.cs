using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.Classes
{
    public class CartProduct
    {
        public int CartId { get; }
        public int ProductId { get; }
        public int Quantity { get; set; }

        public CartProduct(int cartId, int productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
