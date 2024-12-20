﻿using Accessors.Classes;
using Accessors.Interfaces;
using Managers.Interfaces;
using Engines;
using Engines.Interfaces;
using Managers;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    private static void Main()
    {
        //PrintUsers();
        //PrintProducts();
        //PrintCarts();

        //PrintAllProductsByCategory();

        //PrintCurrentSale();
        //Console.WriteLine();
        //PrintProductsOnSale();

        CheckUserCredentialsAndPrintResult();
    }

    public static void CheckUserCredentialsAndPrintResult()
    {
        var accessor = new UserAccessor();

        var u = accessor.VerifyUser("cc@test.com", "not-password");

        if (u != null)
        {
            Console.WriteLine(u.FirstName + " " + u.LastName);
        }
        else
        {
            Console.WriteLine("Wrong Password");
        }
    }

    // A bunch of functions below that I used for initial development.
    // Saving them because they can probably be adapted to make Unit Tests.
    // Additionally useful to see how things work and test the database.
    public static void PrintCategories()
    {
        var accessor = new CategoryAccessor();

        foreach (var cat in accessor.GetAllCategories())
        {
            Console.WriteLine(string.Concat(cat.CategoryId, " - ", cat.CategoryName));
        }
    }
    public static void PrintProductsByCategoryId(int id)
    {
        var accessor = new ProductAccessor();

        foreach (var product in accessor.GetProductsByCategoryId(id))
        {
            Console.WriteLine(string.Concat(product.ProductId, "  ", product.Name, " - ", product.Description, " $", product.Price));
        }
    }

    public static void PrintAllProductsByCategory()
    {
        var catAccessor = new CategoryAccessor();
        var prodAccessor = new ProductAccessor();

        foreach (var category in catAccessor.GetAllCategories())
        {
            Console.WriteLine(string.Concat("----------  ", category.CategoryName, "  ----------"));
            foreach (var product in prodAccessor.GetProductsByCategoryId(category.CategoryId))
            {
                Console.WriteLine(string.Concat(product.ProductId, "  ", product.Name, " - ", product.Description, " $", product.Price));
            }
            Console.WriteLine();
        }
    }
    public static void PrintCurrentSale()
    {
        const int padding = 15;
        var accessor = new SaleAccessor();
        var sale = accessor.GetCurrentSale();

        Console.WriteLine(string.Concat("ID:".PadRight(padding), sale.SaleId, "\n",
            "Sale Name:".PadRight(padding), sale.SaleName, "\n",
            "Discount %:".PadRight(padding), sale.DiscountPercent, "\n",
            "Discount Val:".PadRight(padding), sale.DiscountValue, "\n",
            "Start:".PadRight(padding), sale.StartDate, "\n",
            "End:".PadRight(padding), sale.EndDate));
    }

    public static void PrintProductsOnSale()
    {
        var accessor = new ProductAccessor();

        foreach (var product in accessor.GetProductsOnSale())
        {
            Console.WriteLine(string.Concat(product.ProductId, "  ", product.Name, " - ", product.Description, " $", product.Price));
        }
    }

    public static void AddBobby()
    {
        var accessor = new UserAccessor();

        var u = new User("Bobby", "Hill", "DirtyDan@test.com");

        var success = accessor.AddUserToDb(u, "propane");

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
        var searchResults = manager.SearchBar("daily");
        foreach (var prod in searchResults)
        {
            Console.WriteLine(string.Concat(prod.ProductId) + " " + prod.Name);
        }

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