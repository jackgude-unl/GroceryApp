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
    }

    public interface IUserAccessor
    {
        User? VerifyUser(string email, string password);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool AddUserToDb(User user, string password);
    }

    public interface IProduct
    {
        int ProductId { get; }
        string Name { get; }
        string Description { get; }
        decimal Price { get; }
    }

    public interface IProductAccessor
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategoryId(int id);
        IEnumerable<Product> GetProductsOnSale();
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

    public interface ICartProduct
    {
        int CartId { get; }
        int ProductId { get; }
        int Quantity { get; set; }
    }

    public interface ICartAccessor
    {
        IEnumerable<Cart> GetAllCarts();
        Cart GetCartByCartId(int id);
        Cart GetCartByUserId(int id);
    }

    public interface ICategory
    {
        int CategoryId { get; }
        string CategoryName { get; }
    }

    public interface ICategoryAccessor
    {
        IEnumerable<Category> GetAllCategories();
    }

    public interface ISale
    {
        int SaleId { get; }
        string SaleName { get; }
        decimal DiscountPercent { get; }
        decimal DiscountValue { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
    }

    public interface ISaleAccessor
    {
        Sale GetCurrentSale();
    }
}
