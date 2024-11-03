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
        string UserId { get; }
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
        string ProductId { get; }
        string Name { get; }
        string Description { get; } 
        string Category { get; }
        double Price { get; }
        IEnumerable<string> Images { get; }
    }

    public interface IProductAccessor
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        bool AddProductToDb(Product product);
    }

    public interface ICart
    {
        string CartId { get; }
        string UserId { get; }
        IEnumerable<Product> ProductsInCart { get; }
        bool AddProduct(Product product);
        bool RemoveProduct(Product product);
        double CalculateTotal();
    }

    public interface ICartAccessor
    {
        IEnumerable<Cart> GetAllCarts();
        Cart GetCartByCartId(int id);
        Cart GetCartByUserId(int id);
    }
}
