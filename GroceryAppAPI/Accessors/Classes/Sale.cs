using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;

namespace Accessors.Classes
{
    public class Sale : ISale
    {
        public int SaleId { get; }
        public string SaleName { get; }
        public decimal DiscountPercent { get; }
        public decimal DiscountValue { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Sale(int saleId, string saleName, decimal discountPercent, decimal discountValue, DateTime startDate, DateTime endDate)
        {
            SaleId = saleId;
            SaleName = saleName;
            DiscountPercent = discountPercent;
            DiscountValue = discountValue;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    public class SaleAccessor : ISaleAccessor
    {
        public Sale GetCurrentSale()
        {
            const string query = "SELECT * FROM Sales " + 
                                 "WHERE StartDate < GETDATE() AND " +
                                 "EndDate > GETDATE()";

            var saleData = DatabaseAccessor.ExecuteQuery(query).Rows[0];

            var sale = new Sale((int)saleData[0],
                (string)saleData[1],
                (decimal)saleData[2],
                (decimal)saleData[3],
                (DateTime)saleData[4],
                (DateTime)saleData[5]);

            return sale;
        }
    }
}
