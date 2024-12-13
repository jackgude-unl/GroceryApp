using Accessors.Classes;
using Accessors.Interfaces;
using Managers.Interfaces;
using Engines;
using Engines.Interfaces;
using Managers;
using Microsoft.Identity.Client;

public class Program
{
    private static void Main()
    {
        PrintUsers();
        PrintProducts();
        PrintCarts();
    }

    // A bunch of functions below that I used for initial development.
    // Saving them because they can probably be adapted to make Unit Tests.
    // Additionally useful to see how things work and test the database.
    public static void AddBobby()
    {
        var accessor = new UserAccessor();

        var u = new User("Bobby", "Hill", "DirtyDan@test.com", "propane");

        var success = accessor.AddUserToDb(u);

        Console.WriteLine(success ? "Success" : "Failure");
    }

    public static void PrintUsers()
    {
        var accessor = new UserAccessor();

        var users = accessor.GetAllUsers();
        foreach (var u in users)
        {
            Console.WriteLine(string.Concat(u.UserId, " ", u.FirstName, " ", u.LastName));
        }
    }

    public static void PrintCartById(int id)
    {
        var accessor = new CartAccessor();

        var cart = accessor.GetCartByUserId(id);
        foreach (var cartProd in cart.ProductsInCart)
        {
            Console.WriteLine(cartProd.ProductId);
        }
    }

    public static void PrintCarts()
    {
        var accessor = new CartAccessor();

        var carts = accessor.GetAllCarts();
        foreach (var c in carts)
        {
            Console.WriteLine($"User ID: {c.UserId}");
            foreach (var cartProd in c.ProductsInCart)
            {
                Console.WriteLine(cartProd.ProductId);
            }
        }
    }

    public static void PrintProducts()
    {
        var accessor = new ProductAccessor();
        var engine = new ProductEngine();
        var manager = new ProductManager(accessor, engine);

        var products = accessor.GetAllProducts();

        Console.WriteLine("TEST");
        foreach (var prod in products)
        {
            Console.WriteLine(string.Concat(prod.ProductId) + " " + prod.Name);
        }
    }

    public static void PrintProductById(int id)
    {
        var accessor = new ProductAccessor();

        var prod = accessor.GetProductById(id);

        Console.WriteLine(string.Concat(prod.ProductId) + " " + prod.Name);
    }

    public static void PrintUser(int id)
    {
        var accessor = new UserAccessor();

        var u = accessor.GetUserById(id);

        Console.WriteLine(string.Concat(u.UserId, " ", u.FirstName, " ", u.LastName));
    }
}