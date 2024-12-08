using Accessors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Principal;
using System.Data;

namespace Accessors.Classes
{
    public class Cart : ICart
    {
        public int CartId { get; }
        public int UserId { get; }
        public List<CartProduct> ProductsInCart { get; set; }

        public Cart(int cartId, int userId, List<CartProduct>? productsInCart = null!)
        {
            CartId = cartId;
            UserId = userId;
            ProductsInCart = productsInCart ?? new List<CartProduct>();
        }

        public void AddProduct(int productId, int quantity = 1)
        {
            var cartProduct = new CartProduct(CartId, productId, quantity);
            if (!ProductsInCart.Exists(cartProd => cartProd.ProductId == productId))
                ProductsInCart.Add(cartProduct);
        }

        public void RemoveProduct(Product product)
        {
            ProductsInCart.RemoveAll(prod => prod.ProductId == product.ProductId);
        }

        public double CalculateTotal()
        {
            return 0;
        }
    }

    public class CartProduct : ICartProduct
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

    public class CartAccessor : ICartAccessor
    {
        public IEnumerable<Cart> GetAllCarts()
        {
            const string query1 = "SELECT * FROM Carts";
            const string query2 = "SELECT * FROM CartProducts";
            var cartData = DatabaseAccessor.ExecuteQuery(query1);
            var cartProductData = DatabaseAccessor.ExecuteQuery(query2);

            var cartList = new List<Cart>();
            foreach (DataRow cartRow in cartData.Rows)
            {
                var cart = new Cart((int)cartRow[0],
                    (int)cartRow[1]);

                foreach (DataRow cartProdRow in cartProductData.Rows)
                {
                    if ((int)cartRow[0] == (int)cartProdRow[0])
                    {
                        cart.AddProduct((int)cartProdRow[1], (int)cartProdRow[2]);
                    }
                }

                cartList.Add(cart);
            }

            return cartList;
        }

        public Cart GetCartByCartId(int id)
        {
            const string query1 = "SELECT * FROM Carts WHERE CartID = @CartID";
            const string query2 = "SELECT * FROM CartProducts WHERE CartID = @CartID";

            var parameters = new List<SqlParameter>
            {
                new("@CartID", id)
            };

            var cartData = DatabaseAccessor.ExecuteQuery(query1, parameters);
            var cartProductData = DatabaseAccessor.ExecuteQuery(query2, parameters);

            var cartRow = cartData.Rows[0];
            var cart = new Cart((int)cartRow[0],
                (int)cartRow[1]);

            foreach (DataRow cartProdRow in cartProductData.Rows)
            {
                cart.AddProduct((int)cartProdRow[1], (int)cartProdRow[2]);
            }

            return cart;
        }

        public Cart GetCartByUserId(int id)
        {
            const string query1 = "SELECT * FROM Carts WHERE UserID = @UserID";
            const string query2 = "SELECT * FROM CartProducts WHERE CartID = @CartID";

            var parameters1 = new List<SqlParameter>
            {
                new("@UserID", id)
            };

            var cartData = DatabaseAccessor.ExecuteQuery(query1, parameters1);

            var parameters2 = new List<SqlParameter>
            {
                new("@CartID", (int)cartData.Rows[0][0])
            };

            var cartProductData = DatabaseAccessor.ExecuteQuery(query2, parameters2);

            var cartRow = cartData.Rows[0];
            var cart = new Cart((int)cartRow[0],
                (int)cartRow[1]);

            foreach (DataRow cartProdRow in cartProductData.Rows)
            {
                cart.AddProduct((int)cartProdRow[1], (int)cartProdRow[2]);
            }

            return cart;
        }
    }
}
