using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VgWebApp.Data;
using VgWebApp.Models;
using VgWebApp.Models.ViewModels;

namespace VgWebApp.Controllers
{
    public class ProductController : Controller
    {
        //create a field of type IProductRepository
        private IProductRepository repository;
        //Why this is capitalized I do not know
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            //When this constructor runs it will request an instance
            //of an object that inherits from IProductRepository
            //and we will get an object of type FakeProductRepository
            //and assign it to our repository field.
            repository = repo;
        }
        public ViewResult List(int productPage = 1) => View(new ProductsListViewModel
        {
                Products = repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            });

        //This statement will render a view of the name List.cshtml
        //and send it an Iqueryable of Product as the model
        //By specifying a default parameter 1 will be used if no
        //parameter is given. The stament below first Orders all of the
        //products by Id, then it skips forward past theproducts
        //that would not be listed on that product page, then takes the
        //number of products specified in PageSize
        //public ViewResult List(int productPage = 1) 
        //    => View(repository.Products
        //        .OrderBy(p => p.ProductID)
        //        .Skip((productPage -1) * PageSize)
        //        .Take(PageSize));
        //The above statement is equvalent to the statement below
        //public ViewResult List()
        //{
        //    IQueryable<Product> products = repository.Products.OrderBy(p => p.ProductID)
        //        .Skip((productPage -1) * PageSize)
        //        .Take(PageSize));;
        //    return View(products);
        //}

    }
}