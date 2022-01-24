using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.UnitOfWorks;
using SalesStatisticsDisplaySystem.Models;

namespace SalesStatisticsDisplaySystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISalesDbUnitOfWork _salesDbUoW;

        public ProductController(ISalesDbUnitOfWork salesDbUoW)
        {
            _salesDbUoW = salesDbUoW;
        }

        [HttpGet]
        public IActionResult ProductsPage()
        {
            ViewBag.Title = "Products";

            return View();
        }

        public IEnumerable<SalesStatisticsDisplaySystem.Models.Product> FetchProductTableData()
        {
            var products = _salesDbUoW.ProductRepository
                .Get(null, product => product
                    .OrderBy(p => p.Id));

            foreach (var product in products)
            {
                yield return new Product { Id = product.Id, Name = product.Name, Price = product.Price };
            }
        }
    }
}