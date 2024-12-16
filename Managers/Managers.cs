using Engines.Interfaces;
using Accessors.Classes;
using Accessors.Interfaces;
using Managers.Interfaces;


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
            if (!string.IsNullOrWhiteSpace(search))
            {
                return _ProductEngine.SearchBar(products, search).ToList();
            }
            else
            {
                return products.ToList();
            }
        }
    }
}
