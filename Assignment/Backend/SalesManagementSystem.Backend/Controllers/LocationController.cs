using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.BusinessLayer.Models;
using SalesManagementSystem.BusinessLayer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesManagementSystem.Backend.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationServices locationServices;
        public LocationController(ILocationServices locationServices)
        {
            this.locationServices = locationServices;
        }
        // GET: api/locations
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return locationServices.Locations;
        }
    }
}
