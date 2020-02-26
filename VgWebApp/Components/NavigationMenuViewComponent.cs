using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VgWebApp.Data;
using VgWebApp.Models;

namespace VgWebApp.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        //This is the method that will grab the genre values from the route data using the
        //ViewBag.SelectedGenre property and return the view
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Products
                .Select(x => x.Genre)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
