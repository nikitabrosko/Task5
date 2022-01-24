using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.UnitOfWorks;
using DatabaseLayer.Contexts;
using SalesStatisticsDisplaySystem.Models;

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
    }
}