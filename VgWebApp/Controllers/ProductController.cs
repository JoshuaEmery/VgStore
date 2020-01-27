using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VgWebApp.Data;
using VgWebApp.Models;

namespace VgWebApp.Controllers
{
    public class ProductController : Controller
    {
        //create a field of type IProductRepository
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            //When this constructor runs it will request an instance
            //of an object that inherits from IProductRepository
            //and we will get an object of type FakeProductRepository
            //and assign it to our repository field.
            repository = repo;
        }
        //This statement will render a view of the name List.cshtml
        //and send it an Iqueryable of Product as the model
        public ViewResult List() => View(repository.Products);
        //The above statement is equvalent to the statement below
        //public ViewResult List()
        //{
        //    IQueryable<Product> products = repository.Products;
        //    return View(products);
        //}

    }
}