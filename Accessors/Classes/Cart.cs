using Accessors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Principal;

namespace Accessors.Classes
{
    public class Cart : ICart
    {
        public int CartId { get; }
        public int UserId { get; }
        public IEnumerable<Product> ProductsInCart { get; }

        public Cart(int cartId, int userId, IEnumerable<Product> productsInCart)
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
        private const string ConnectionString = "Server=localhost\\sqlexpress; Database=CSCE361; Trusted_Connection=True; Encrypt=false;";

        public IEnumerable<Cart> GetAllCarts()
        {
            Database db = new Database();
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

        public void Test()
        {
            
        }

        public SqlConnection GetDatabaseConnection()
        {
            SqlConnection connection = null;
            // use a try block to set the SQL connection string and open it. If it fails print the errors and return false.
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return connection;
        }
    }
}
