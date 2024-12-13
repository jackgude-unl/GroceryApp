using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors.Classes;
using Accessors.Interfaces;

namespace Engines.Interfaces
{
    public interface IProductEngine
    {
        List<Product> SearchBar(IEnumerable<Product> products, string search);
    }
}
