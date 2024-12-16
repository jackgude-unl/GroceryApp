using Accessors.Classes;


namespace Managers.Interfaces
{
    public interface IProductManager
    {
        List<Product> SearchBar(string search);
    }
}
