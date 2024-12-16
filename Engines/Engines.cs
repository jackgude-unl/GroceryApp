using System.Data;
using Accessors.Classes;
using Engines.Interfaces;

namespace Engines
{
    public class ProductEngine : IProductEngine
    {
        public List<Product> SearchBar(IEnumerable<Product> products, string search)
        {
            return products
                .Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
