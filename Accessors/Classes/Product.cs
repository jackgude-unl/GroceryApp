using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;

namespace Accessors.Classes
{
    public class Product : IProduct
    {
        public string ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public string Category { get; }
        public double Price { get;}
        public IEnumerable<string> Images { get; }

        public Product(string productId, string name, string description, string category, double price, IEnumerable<string> images)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Images = images;
        }
    }

    public class ProductAccessor : IProductAccessor
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return null;
        }

        public Product GetProductById(int id)
        {
            return null;
        }

        public bool AddProductToDb(Product product)
        {
            return false;
        }
    }
}
