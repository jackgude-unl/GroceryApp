using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors.Classes;
using Accessors.Interfaces;
using Engines.Interfaces;

namespace Engines
{
    public class ProductEngine : IProductEngine
    {
        public List<Product> SearchBar(IEnumerable<Product> products, string search)
        {
            return products
                .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
