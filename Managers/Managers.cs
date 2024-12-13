using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engines.Interfaces;
using Accessors.Classes;
using Accessors.Interfaces;
using Managers.Interfaces;
using Engines;


namespace Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductAccessor _ProductAccessor;
        private readonly IProductEngine _ProductEngine;

        public ProductManager(IProductAccessor productAccessor, IProductEngine productEngine)
        {
            _ProductAccessor = productAccessor;
            _ProductEngine = productEngine;
        }

        public List<Product> SearchBar(string search)
        {
            var products = _ProductAccessor.GetAllProducts();
            if (category != null)
            {
                return _ProductEngine.SortByCategory(products, category).ToList();
            }
            else
            {
                return products.ToList();
            }
        }
    }
}
