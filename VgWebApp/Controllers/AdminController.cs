using Microsoft.AspNetCore.Mvc;
using VgWebApp.Data;
using System.Linq;

namespace VgWebApp.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));

        public ViewResult Index() => View(repository.Products);
    }
}