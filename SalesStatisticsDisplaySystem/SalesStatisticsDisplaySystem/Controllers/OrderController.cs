using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.UnitOfWorks;
using SalesStatisticsDisplaySystem.Models;

namespace SalesStatisticsDisplaySystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISalesDbUnitOfWork _salesDbUoW;

        public OrderController(ISalesDbUnitOfWork salesDbUoW)
        {
            _salesDbUoW = salesDbUoW;
        }

        [HttpGet]
        public IActionResult OrdersPage()
        {
            ViewBag.Title = "Orders";

            return View();
        }

        public IEnumerable<SalesStatisticsDisplaySystem.Models.Order> FetchOrderTableData()
        {
            var orders = _salesDbUoW.OrderRepository
                .Get(null, order => order
                    .OrderBy(o => o.Id));

            foreach (var order in orders)
            {
                yield return new Order
                {
                    Id = order.Id,
                    Date = order.Date,
                    Sum = order.Sum,
                    CustomerFullName = order.Customer.FullName,
                    ManagerLastName = order.Manager.LastName,
                    ProductName = order.Product.Name
                };
            }
        }
    }
}