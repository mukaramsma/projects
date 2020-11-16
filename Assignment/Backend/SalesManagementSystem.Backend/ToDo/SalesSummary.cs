using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManagementSystem.Backend.ToDo
{
    public class SalesData
    { 
        public int Duration { get; set; }
        public int Value { get; set; }
    }
    public class SalesSummary
    {
        public string Location { get; set; }
        public IEnumerable<SalesData> SalesDatas { get; set; }
        public int Sum { get { return SalesDatas.Sum(x => x.Value); } }
        public decimal Average { get { return Sum == 0 ? Sum : (decimal) Sum / SalesDatas.Count(); } }
        public int Median { get
            {
                if (!SalesDatas.Any())
                    return 0;

                var sortedList = SalesDatas.Select(x => x.Value).OrderBy(x => x).ToArray();

                var medIndex = sortedList.Count() >> 1;

                if ((sortedList.Count() & 1) == 1)
                    return sortedList[medIndex];

                return (sortedList[medIndex] + sortedList[medIndex - 1]) / 2;

            } 
        }
    }
}
