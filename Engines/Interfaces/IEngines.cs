using Accessors.Classes;

namespace Engines.Interfaces
{
    public interface IProductEngine
    {
        List<Product> SearchBar(IEnumerable<Product> products, string search);
    }
}
