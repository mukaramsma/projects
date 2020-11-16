using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SalesManagementSystem.BusinessLayer.Models;

namespace SalesManagementSystem.BusinessLayer.Services
{
    public interface ISalesSummaryServices
    {
        void AddSaleInfo(SaleInfo salesInfo);

        IEnumerable<SaleInfo> SaleInfos { get; }
    }
}
