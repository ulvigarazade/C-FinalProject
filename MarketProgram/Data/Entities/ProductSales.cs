using MarketProgram.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProgram.Data.Entities
{
    public class ProductSales : BaseEntity
    {
        private static int count;

        public int No { get; set; }
        public double Price { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public DateTime Date { get; set; }

        public ProductSales()
        {
            count++;
            No = count;
            SaleItems = new();
            Date = DateTime.Now;
        }

        
    }
}
