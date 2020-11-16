using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SalesManagementSystem.BusinessLayer.Services;
using SalesManagementSystem.BusinessLayer.Models;
using SalesManagementSystem.Backend.Controllers;

namespace SalesManagementSystem.NUnit.Test
{
    public abstract class BaseTest
    {
        protected Mock<ISalesSummaryServices> mockSalesSummayServices = new Mock<ISalesSummaryServices>();
        protected Mock<ILocationServices> mockLocationServices = new Mock<ILocationServices>();
        protected readonly Location chicagoLocation = new Location("USA", "IL", "Chicago");
        protected readonly Location nyLocation = new Location("USA", "NY", "New York");
        protected readonly Location mumbaiLocation = new Location("India", "MH", "Mumbai");
        protected readonly SalesSummaryController salesSummaryController;

        protected BaseTest()
        {
            salesSummaryController = new SalesSummaryController(mockSalesSummayServices.Object, mockLocationServices.Object);
            mockSalesSummayServices.Setup(x => x.SaleInfos).Returns(new List<SaleInfo>
            {
                new SaleInfo{Location=chicagoLocation, SaleDate = DateTime.Now.AddMonths(-1), TotalSales = 100},
                new SaleInfo{Location=nyLocation, SaleDate = DateTime.Now.AddMonths(-1), TotalSales = 400},
                new SaleInfo{Location=chicagoLocation, SaleDate = DateTime.Now, TotalSales = 100},
                new SaleInfo{Location=mumbaiLocation, SaleDate = DateTime.Now, TotalSales = 300},
            });
        }

    }
}
