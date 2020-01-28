using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VgWebApp.Models;

namespace VgWebApp.Data
{
    //This is the class that will provide access to the Product
    //table in the database.  Through implementing IProductRepository
    //this service can be injected into the constructors where it is needed.
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
