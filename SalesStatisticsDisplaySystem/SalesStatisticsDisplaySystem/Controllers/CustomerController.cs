using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstractions.UnitOfWorks;
using SalesStatisticsDisplaySystem.Models;

namespace SalesStatisticsDisplaySystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ISalesDbUnitOfWork _salesDbUoW;

        public CustomerController(ISalesDbUnitOfWork salesDbUoW)
        {
            _salesDbUoW = salesDbUoW;
        }

        [HttpGet]
        public IActionResult CustomersPage()
        {
            ViewBag.Title = "Customers";

            return View();
        }

        public IEnumerable<SalesStatisticsDisplaySystem.Models.Customer> FetchCustomerTableData()
        {
            var customers = _salesDbUoW.CustomerRepository
                .Get(null, customer => customer
                    .OrderBy(c => c.Id));

            foreach (var customer in customers)
            {
                yield return new Customer
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    FullName = customer.FullName
                };
            }
        }
    }
}
