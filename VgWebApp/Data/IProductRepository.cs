using VgWebApp.Models;
using System.Linq;


namespace VgWebApp.Data
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
