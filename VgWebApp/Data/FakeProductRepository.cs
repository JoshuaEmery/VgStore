using VgWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace VgWebApp.Data
{
    //this FakeRepository implements the IProduct Repository
    //The reason for this is that when registering a service
    //with the services collection an interface needs to 
    //be provided to use as a blueprint for the service to
    //function
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product> {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
            }.AsQueryable<Product>();
    }
}
