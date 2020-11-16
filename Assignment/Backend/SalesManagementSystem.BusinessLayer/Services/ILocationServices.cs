using System.Linq;
using SalesManagementSystem.BusinessLayer.Models;

namespace SalesManagementSystem.BusinessLayer.Services
{
    public interface ILocationServices
    {
        IQueryable<Location> Locations { get; }
        void TryAddLocation(Location country);
    }
}
