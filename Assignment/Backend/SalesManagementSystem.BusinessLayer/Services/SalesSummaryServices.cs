using SalesManagementSystem.BusinessLayer.DbContext;
using SalesManagementSystem.BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesManagementSystem.BusinessLayer.Services
{
    public sealed class SalesSummaryServices : ISalesSummaryServices
    {
        private readonly AppDbContext dbContext;
        private readonly ILocationServices locationServices;
        public SalesSummaryServices(AppDbContext dbContext, ILocationServices locationServices)
        {
            this.dbContext = dbContext;
            this.locationServices = locationServices;
            LoadData();
        }

        private void LoadData()
        {
            var salesInfo = Helpers.Util.GetSalesInfo();

            foreach (var sales in salesInfo)
            {
                sales.Location = locationServices.Locations.FirstOrDefault(x => x.Code == sales.Location.Code);
                dbContext.SalesInfo.Add(sales);
            }
            dbContext.SaveChanges();
        }

        public IEnumerable<SaleInfo> SaleInfos => dbContext.SalesInfo;

        public void AddSaleInfo(SaleInfo salesInfo)
        {
            dbContext.SalesInfo.Add(salesInfo);
            dbContext.SaveChanges();
            Helpers.Util.SaveSalesData(dbContext.SalesInfo);
        }
    }
}
