using MarketProgram.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProgram.Data.Entities
{
    public class SaleItem : BaseEntity
    {
        private static int count;
        public int No { get; set; }
        public Products  Product { get; set; }
        public int Quantity { get; set; }
        public SaleItem()
        {
            count++;
            No = count;
        }


    }
}
