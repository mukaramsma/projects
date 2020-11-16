using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.BusinessLayer.Models
{
    public class SaleInfo
    {
        public SaleInfo()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
        public Location Location { get; set; }
        public DateTime SaleDate { get; set; }
        public int TotalSales { get; set; }
    }
}
