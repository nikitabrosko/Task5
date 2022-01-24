using System;
using System.ComponentModel.DataAnnotations;

namespace SalesStatisticsDisplaySystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        public decimal Sum { get; set; }

        public string CustomerFullName { get; set; }

        public string ManagerLastName { get; set; }

        public string ProductName { get; set; }
    }
}