using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.UnitOfWorks;
using SalesStatisticsDisplaySystem.Models;

namespace SalesStatisticsDisplaySystem.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ISalesDbUnitOfWork _salesDbUoW;

        public ManagerController(ISalesDbUnitOfWork salesDbUoW)
        {
            _salesDbUoW = salesDbUoW;
        }

        [HttpGet]
        public IActionResult ManagersPage()
        {
            ViewBag.Title = "Managers";

            return View();
        }

        public IEnumerable<SalesStatisticsDisplaySystem.Models.Manager> FetchManagerTableData()
        {
            var managers = _salesDbUoW.ManagerRepository
                .Get(null, manager => manager
                    .OrderBy(m => m.Id));

            foreach (var manager in managers)
            {
                yield return new Manager { Id = manager.Id, LastName = manager.LastName };
            }
        }
    }
}
