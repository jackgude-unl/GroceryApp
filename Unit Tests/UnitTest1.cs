using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Accessors.Classes;
using Accessors.Interfaces;
using Managers.Interfaces;
using Engines;
using Engines.Interfaces;
using Managers;


namespace Unit_Tests
{
    public class ManagerTests
    {
        [Fact]
        public void SearchBar_DescriptionSearch()
        {
            //Arrange
            var mockProductAccessor = new Mock<IProductAccessor>();
            var mockProductEngine = new Mock<IProductEngine>();

            var products = new List<Product>
            {
                new Product(1, "French Bread", "Daily French break Frshinhly baked", (decimal)3.49),
                new Product(2, "Apple", "Organic pink lady apples", (decimal)2.99),
                new Product(3, "Ribeye", "Words can't describe how this steak", (decimal)1000.38),
                new Product(4, "Milk", "The best whole milk the you have ever tasted :)", (decimal)100.99)
            };

            mockProductAccessor.Setup(x => x.GetAllProducts()).Returns(products);
            mockProductEngine.Setup(x => x.SearchBar(products, "Steak")).Returns(products.Where(p => p.Description.Contains("steak", System.StringComparison.OrdinalIgnoreCase)).ToList());
            var productManager = new ProductManager(mockProductAccessor.Object, mockProductEngine.Object);

            //Act
            var results = productManager.SearchBar("Steak");

            //Assert
            Assert.Single(results);
            Assert.Equal("Ribeye", results.First().Name);
        }

        [Fact]
        public void SearchBar_Empty()
        {
            //Arrange
            var mockProductAccessor = new Mock<IProductAccessor>();
            var mockProductEngine = new Mock<IProductEngine>();

            var products = new List<Product>
            {
                new Product(1, "French Bread", "Daily French break Frshinhly baked", (decimal)3.49),
                new Product(2, "Apple", "Organic pink lady apples", (decimal)2.99),
                new Product(3, "Ribeye", "Words can't describe how this steak", (decimal)1000.38),
                new Product(4, "Milk", "The best whole milk the you have ever tasted :)", (decimal)100.99)
            };

            mockProductAccessor.Setup(x => x.GetAllProducts()).Returns(products);
            var productManager = new ProductManager(mockProductAccessor.Object, mockProductEngine.Object);

            //Act
            var results = productManager.SearchBar(string.Empty);

            //Assert
            Assert.Equal(4, results.Count);
        }

        [Fact]
        public void SearchBar_NameSearch()
        {
            //Arrange
            var mockProductAccessor = new Mock<IProductAccessor>();
            var mockProductEngine = new Mock<IProductEngine>();

            var products = new List<Product>
            {
                new Product(1, "French Bread", "Daily French break Frshinhly baked", (decimal)3.49),
                new Product(2, "Apple", "Organic pink lady apples", (decimal)2.99),
                new Product(3, "Ribeye", "Words can't describe how this steak", (decimal)1000.38),
                new Product(4, "Milk", "The best whole milk the you have ever tasted :)", (decimal)100.99)
            };

            mockProductAccessor.Setup(x => x.GetAllProducts()).Returns(products);
            mockProductEngine.Setup(x => x.SearchBar(products, "milk")).Returns(products.Where(p => p.Name.Contains("milk", System.StringComparison.OrdinalIgnoreCase)).ToList());
            var productManager = new ProductManager(mockProductAccessor.Object, mockProductEngine.Object);

            //Act
            var results = productManager.SearchBar("milk");

            //Assert
            Assert.Single(results);
            Assert.Equal("Milk", results.First().Name);
        }
    }
}