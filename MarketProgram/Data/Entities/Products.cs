using MarketProgram.Data.Common;
using MarketProgram.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProgram.Data.Entities
{
    public class Products : BaseEntity
    {
        private static int count;

        public string Name { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public ProductsCategory Category { get; set; }

        public Products()
        {
            count++;

            No = count;          
            Category = ProductsCategory.xeta;
        }



          
    }
        

    }

