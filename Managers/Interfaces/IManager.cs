using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors.Classes;
using Accessors.Interfaces;
using Engines.Interfaces;


namespace Managers.Interfaces
{
    public interface IProductManager
    {
        List<Product> SearchBar(string search);
    }
}
