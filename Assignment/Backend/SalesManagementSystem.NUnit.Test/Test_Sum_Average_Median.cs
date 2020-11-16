using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using SalesManagementSystem.Backend.Controllers;
using SalesManagementSystem.Backend.ToDo;

namespace SalesManagementSystem.NUnit.Test
{
    public sealed class Test_Sum_Average_Median : BaseTest
    {
        [Test]
        public void Test_Sum_By_Country()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 0, Year = 2020 });
            Assert.AreEqual(600, result.First().Sum);
        }

        [Test]
        public void Test_Sum_By_State()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 1, Year = 2020 });
            Assert.AreEqual(200, result.First().Sum);
        }

        [Test]
        public void Test_Sum_By_City()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 2, Year = 2020 });
            Assert.AreEqual(200, result.First().Sum);
        }

        [Test]
        public void Test_Average_By_Country()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 0, Year = 2020 });
            Assert.AreEqual(300, result.First().Average);
        }

        [Test]
        public void Test_Average_By_State()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 1, Year = 2020 });
            Assert.AreEqual(100, result.First().Average);
        }

        [Test]
        public void Test_Average_By_City()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 2, Year = 2020 });
            Assert.AreEqual(100, result.First().Average);
        }

        [Test]
        public void Test_Median_By_Country()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 0, Year = 2020 });
            Assert.AreEqual(300, result.First().Median);
        }

        [Test]
        public void Test_Median_By_State()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 1, Year = 2020 });
            Assert.AreEqual(100, result.First().Median);
        }

        [Test]
        public void Test_Median_By_City()
        {
            var result = salesSummaryController.Get(new SalesSummaryFilter { LocationType = 2, Year = 2020 });
            Assert.AreEqual(100, result.First().Median);
        }
    }
}
