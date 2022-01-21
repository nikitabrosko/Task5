using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.UnitOfWorks;
using DatabaseLayer.Contexts;
using DatabaseLayer.Models;

namespace SalesStatisticsDisplaySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalesDbUnitOfWork _salesDbUoW;

        public HomeController(ISalesDbUnitOfWork salesDbUoW)
        {
            _salesDbUoW = salesDbUoW;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Home page";

            return View();
        }

        public IEnumerable<Customer> FetchCustomerTableData()
        {
            return _salesDbUoW.CustomerRepository.Get();
        }

        [HttpGet]
        public IActionResult CustomersPage()
        {
            ViewBag.Title = "Customers";

            return View();
        }

        public IEnumerable<Manager> FetchManagerTableData()
        {
            return _salesDbUoW.ManagerRepository.Get();
        }

        [HttpGet]
        public IActionResult ManagersPage()
        {
            ViewBag.Title = "Managers";

            return View();
        }

        public IEnumerable<Product> FetchProductTableData()
        {
            return _salesDbUoW.ProductRepository.Get();
        }

        [HttpGet]
        public IActionResult ProductsPage()
        {
            ViewBag.Title = "Products";

            return View();
        }

        public IEnumerable<Order> FetchOrderTableData()
        {
            return _salesDbUoW.OrderRepository.Get();
        }

        [HttpGet]
        public IActionResult OrdersPage()
        {
            ViewBag.Title = "Orders";

            return View();
        }
    }
}