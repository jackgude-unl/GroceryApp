using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;
using Microsoft.Data.SqlClient;

namespace Accessors.Classes
{
    public class Product : IProduct
    {
        public int ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get;}

        public Product(int productId, string name, string description, decimal price)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
        }
    }

    public class ProductAccessor : IProductAccessor
    {
        public IEnumerable<Product> GetAllProducts()
        {
            const string query = "SELECT * FROM Products";
            var userData = DatabaseAccessor.ExecuteQuery(query);

            var productList = new List<Product>();
            foreach (DataRow row in userData.Rows)
            {
                var product = new Product((int)row[0],
                    row[1].ToString()!,
                    row[2].ToString()!,
                    (decimal)row[3]
                    );

                productList.Add(product);
            }

            return productList;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            const string query = "SELECT p.ProductID, ProductName, ProductDescription, Price FROM Categories c " +
                                 "JOIN CategoriesProducts cp on c.CategoryID = cp.CategoryID " +
                                 "JOIN Products p on p.ProductID = cp.ProductID " +
                                 "WHERE c.CategoryID = @CategoryID";

            var parameters = new List<SqlParameter>()
            {
                new("@CategoryID", id)
            };

            var productData = DatabaseAccessor.ExecuteQuery(query, parameters);

            var productList = new List<Product>();
            foreach (DataRow row in productData.Rows)
            {
                var prod = new Product((int)row[0], (string)row[1], (string)row[2], (decimal)row[3]);
                productList.Add(prod);
            }

            return productList;
        }

        public IEnumerable<Product> GetProductsOnSale()
        {
            var saleAccessor = new SaleAccessor();
            var currSale = saleAccessor.GetCurrentSale();

            const string query = "SELECT p.ProductID, ProductName, ProductDescription, Price FROM Sales s " +
                                 "JOIN SalesCategories sc on s.SaleID = sc.SaleID " +
                                 "JOIN CategoriesProducts cp on cp.CategoryID = sc.CategoryID " +
                                 "JOIN Products p on p.ProductID = cp.ProductID " +
                                 "WHERE StartDate < GETDATE() AND " +
                                 "EndDate > GETDATE()";

            var productData = DatabaseAccessor.ExecuteQuery(query);

            var productList = new List<Product>();
            foreach (DataRow row in productData.Rows)
            {
                var prod = new Product((int)row[0], (string)row[1], (string)row[2], (decimal)row[3]);
                productList.Add(prod);
            }

            return productList;
        }

        public Product GetProductById(int id)
        {
            const string query = "SELECT * FROM Products WHERE ProductID = @Id";

            var parameters = new List<SqlParameter>
            {
                new("@Id", id)
            };

            var productData = DatabaseAccessor.ExecuteQuery(query, parameters);

            var row = productData.Rows[0];
            var product = new Product((int)row[0],
                row[1].ToString()!,
                row[2].ToString()!,
                (decimal)row[3]
                );

            return product;
        }
    }
}
