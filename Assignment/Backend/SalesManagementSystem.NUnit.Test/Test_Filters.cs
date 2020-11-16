using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using SalesManagementSystem.BusinessLayer.Models;
using SalesManagementSystem.Backend.Controllers;
using SalesManagementSystem.Backend.ToDo;

namespace SalesManagementSystem.NUnit.Test
{
    public class Test_Filters : BaseTest
    {
        [Test]
        public void Filter_By_Country_Then_By_Month()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 0, Year = 2020 });

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("USA", result.First().Location);
            Assert.AreEqual("India", result.Last().Location);

            Assert.AreEqual(DateTime.Now.Month - 1, result.First().SalesDatas.First().Duration );
            Assert.AreEqual(DateTime.Now.Month, result.First().SalesDatas.Last().Duration);
        }

        [Test]
        public void Filter_By_Country_Then_By_Year()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 0, Year = 0 });

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("USA", result.First().Location);
            Assert.AreEqual("India", result.Last().Location);

            Assert.AreEqual(DateTime.Now.Year, result.First().SalesDatas.First().Duration );
            Assert.AreEqual(DateTime.Now.Year, result.First().SalesDatas.Last().Duration );
        }

        [Test]
        public void Filter_By_State_Then_By_Month()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 1, Year = 2020 });

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("IL", result.First().Location);
            Assert.AreEqual("MH", result.Last().Location);

            Assert.AreEqual(DateTime.Now.Month - 1, result.First().SalesDatas.First().Duration);
            Assert.AreEqual(DateTime.Now.Month, result.First().SalesDatas.Last().Duration);
        }

        [Test]
        public void Filter_By_State_Then_By_Year()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 1, Year = 0 });

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("IL", result.First().Location);
            Assert.AreEqual("MH", result.Last().Location);

            Assert.AreEqual(DateTime.Now.Year, result.First().SalesDatas.First().Duration);
            Assert.AreEqual(DateTime.Now.Year, result.First().SalesDatas.Last().Duration);
        }

        [Test]
        public void Filter_By_City_Then_By_Month()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 2, Year = 2020 });

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Chicago", result.First().Location);
            Assert.AreEqual("Mumbai", result.Last().Location);

            Assert.AreEqual(DateTime.Now.Month - 1, result.First().SalesDatas.First().Duration);
            Assert.AreEqual(DateTime.Now.Month, result.First().SalesDatas.Last().Duration);
        }

        [Test]
        public void Filter_By_City_Then_By_Year()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 2, Year = 0 });

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Chicago", result.First().Location);
            Assert.AreEqual("Mumbai", result.Last().Location);

            Assert.AreEqual(DateTime.Now.Year, result.First().SalesDatas.First().Duration);
            Assert.AreEqual(DateTime.Now.Year, result.First().SalesDatas.Last().Duration);
        }

    }
}