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
        public IEnumerable<string> Images { get; } 

        public Product(int productId, string name, string description, decimal price, IEnumerable<string> images = null!)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Images = images;
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
                    (decimal)row[3]);

                productList.Add(product);
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
                (decimal)row[3]);

            return product;
        }
    }
}
