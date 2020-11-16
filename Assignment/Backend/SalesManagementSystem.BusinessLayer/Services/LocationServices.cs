using SalesManagementSystem.BusinessLayer.DbContext;
using SalesManagementSystem.BusinessLayer.Models;
using System.Linq;

namespace SalesManagementSystem.BusinessLayer.Services
{
    public class LocationServices : ILocationServices
    {
        private readonly AppDbContext dbContext;
        public LocationServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            LoadData();
        }

        private void LoadData()
        {
            dbContext.Locations.AddRange(Helpers.Util.GetLocationInfo());
            dbContext.SaveChanges();
        }

        public void TryAddLocation(Location location)
        {
            var locationCode = location.GetCode();

            if (Locations.Any(loc => loc.Code.Equals(locationCode)))
                return;

            dbContext.Locations.Add(location);
            dbContext.SaveChanges();
            Helpers.Util.SaveLocationData(dbContext.Locations);
        }

        public IQueryable<Location> Locations => dbContext.Locations;
    }
}
