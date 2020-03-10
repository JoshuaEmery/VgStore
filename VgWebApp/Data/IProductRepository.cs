using VgWebApp.Models;
using System.Linq;


namespace VgWebApp.Data
{
    //This class provides a template for the EFProduct repository to implement
    //this allows the EFProduct repository to be injected.
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
    }
    
}
