using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.BusinessLayer.Models;
using SalesManagementSystem.BusinessLayer.Services;
using SalesManagementSystem.Backend.ToDo;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesManagementSystem.Backend.Controllers
{
    [EnableCors("allowAllPolicy")]
    [Route("api/salessummary")]
    [ApiController]
    public class SalesSummaryController : ControllerBase
    {
        private readonly ISalesSummaryServices salesSummaryServices;
        private readonly ILocationServices locationServices;
        public SalesSummaryController(ISalesSummaryServices salesSummaryServices, ILocationServices locationServices)
        {
            this.salesSummaryServices = salesSummaryServices;
            this.locationServices = locationServices;
        }

        [HttpPost]
        public void Post([FromBody] NewSummary newSummary)
        {
            var location = new Location(newSummary.Country, newSummary.State, newSummary.City);

            // Add location if not areadly added
            locationServices.TryAddLocation(location);

            // Add sales information
            salesSummaryServices.AddSaleInfo(new SaleInfo
            {
                Location = locationServices.Locations.First(x => x.Code == location.Code),
                SaleDate = DateTime.ParseExact(newSummary.SaleDate, "yyyy-MM", CultureInfo.InvariantCulture),
                TotalSales = newSummary.TotalSales
            });
        }

        [HttpGet]
        public IEnumerable<SalesSummary> Get([FromQuery] SalesSummaryFilter summaryFilter)
        {
            // if year = 0 then group items by year else group items by month for the given year
            var year = summaryFilter.Year;

            // Group location - 0 for Country, 1 for State, 2 for City
            var locationType = summaryFilter.LocationType;
            
            return from salesInfo in salesSummaryServices.SaleInfos
                   group salesInfo by (locationType == 1 ? salesInfo.Location.State : (locationType == 0 ? salesInfo.Location.Country : salesInfo.Location.City))
                   into locationGroup
                   select new SalesSummary
                   { 
                        Location = locationGroup.Key,
                        SalesDatas = from data in locationGroup
                                     where year == 0 || data.SaleDate.Year == year
                                     group data by (year == 0 ? data.SaleDate.Year : data.SaleDate.Month ) into durationGroup
                                     select new SalesData 
                                     {
                                         Duration = durationGroup.Key,
                                         Value = durationGroup.Sum(x=>x.TotalSales)
                                     }
                   };

        }
    }
}
