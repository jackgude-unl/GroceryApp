using Accessors.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.Interfaces
{
    public interface IUser
    {
        int UserId { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Password { get; }
    }

    public interface IUserAccessor
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool AddUserToDb(User user);
    }

    public interface IProduct
    {
        int ProductId { get; }
        string Name { get; }
        string Description { get; }
        decimal Price { get; }
        IEnumerable<string> Images { get; }
        string Category { get; }
    }

    public interface IProductAccessor
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }

    public interface ICart
    {
        int CartId { get; }
        int UserId { get; }
        List<CartProduct> ProductsInCart { get; }
        void AddProduct(int productId, int quantity);
        void RemoveProduct(Product product);
        double CalculateTotal();
    }

    public interface ICartAccessor
    {
        IEnumerable<Cart> GetAllCarts();
        Cart GetCartByCartId(int id);
        Cart GetCartByUserId(int id);
    }
}
