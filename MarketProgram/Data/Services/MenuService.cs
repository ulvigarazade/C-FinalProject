using ConsoleTables;
using MarketProgram.Data.Entities;
using MarketProgram.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProgram.Data.Services
{
    public static class MenuService
    {
        #region Product
        //Product operations
        static MarketManage marketManage = new();
        //public static void AddProduct(Products product)
        //{
        //    Console.WriteLine("Insert Product Name");
        //    string Name = Console.ReadLine();
        //    Console.WriteLine("Insert Product Price");
        //    string PriceStr = Console.ReadLine();
        //    Console.WriteLine("Insert Quantity");
        //    string QuantityStr = Console.ReadLine();
        //    Console.WriteLine("Insert Id");
        //    string IdStr = Console.ReadLine();

        //    try
        //    {
        //        marketManage.AddProduct(Name, double.Parse(PriceStr), int.Parse(QuantityStr), int.Parse(IdStr));
        //        Console.WriteLine("Product Inserted");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Please Try Again");
        //        Console.WriteLine(e.Message);
        //    }
        //}

        internal static void AddProductMenu()
        {
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the price");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Category");
            Enum.TryParse<ProductsCategory>(Console.ReadLine(), true, out ProductsCategory category);



            try
            {
                marketManage.AddProduct(name, price, quantity, category);
                Console.WriteLine("Mehsul daxil edildi");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void EditProductMenu()
        {
            Console.WriteLine("Enter ID");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ProductPrice");
            double ProductPrice = double.Parse(Console.ReadLine());
            //int newId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity");
            int Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Category");
            string Category = Console.ReadLine();
            try
            {
                marketManage.EditProduct(Id, name, ProductPrice, Quantity, Category);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        internal static void DeleteProduct()
        {
            Console.WriteLine("Enter Id ");
            int Id = int.Parse(Console.ReadLine());
            try
            {
                marketManage.DeleteProduct(Id);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static void DisplayAllProduct()
        {
            try
            {
                marketManage.DisplayAllProducts();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            var table = new ConsoleTable("Id", "Name", "ProductPrice", "Quantity", "Category");
            foreach (var products in marketManage.Product)
            {
                table.AddRow(products.No, products.Name, products.ProductPrice.ToString("#.00"), products.Quantity, products.Category);
            }
            table.Write();
            Console.WriteLine();

        }
        public static void SearchCategoryForProduct2()
        {
            Console.WriteLine("Enter Category");
            Enum.TryParse(Console.ReadLine(), false, out ProductsCategory category);
            try
            {
                marketManage.SearchCategoryForProduct(category);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            var table = new ConsoleTable("Id", "Name", "ProductPrice", "Quantity", "Category");
            foreach (var products in marketManage.SearchCategoryForProduct(category))
            {
                table.AddRow(products.No, products.Name, products.ProductPrice.ToString("#.00"), products.Quantity, products.Category);
            }
            table.Write();
            Console.WriteLine();


        }
        public static void SearchPriceRangeProduct()
        {

            Console.WriteLine("Enter min value");
            int minprice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter max value");
            int maxprice = int.Parse(Console.ReadLine());
            try
            {
                marketManage.SearchPriceRangeProduct(minprice, maxprice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            var table = new ConsoleTable("Id", "Name", "ProductPrice", "Quantity", "Category");
            foreach (var products in marketManage.SearchPriceRangeProduct(minprice, maxprice))
            {
                table.AddRow(products.No, products.Name, products.ProductPrice.ToString("#.00"), products.Quantity, products.Category);
            }
            table.Write();
            Console.WriteLine();

        }
        public static void SearchNameForProduct()
        {
            Console.WriteLine("Plase enter name : ");
            string name = Console.ReadLine();

            try
            {
                marketManage.SearchNameForProduct(name);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            var table = new ConsoleTable("Id", "Name", "ProductPrice", "Quantity", "Category");
            foreach (var products in marketManage.SearchNameForProduct(name))
            {
                table.AddRow(products.No, products.Name, products.ProductPrice.ToString("#.00"), products.Quantity, products.Category);
            }
            table.Write();
            Console.WriteLine();

        }

        #endregion





        #region
      
        public static void AddSales()
        {
            Console.WriteLine("Insert No");
            string No = Console.ReadLine();
            Console.WriteLine("Insert Price");
            string Price = Console.ReadLine();
            Console.WriteLine("Insert Sale Item");
            string SaleItem = Console.ReadLine();
            
            try
            {
                marketManage.AddSale(int.Parse(No), double.Parse(Price), SaleItem);
                Console.WriteLine("Add Sale Inserted");

            }
            catch (Exception e)
            {
                Console.WriteLine("Please Try Again");
                Console.WriteLine(e.Message);
            }
        }
        public static void ReturnSales()
        {
            int no = 0;
            int count = 0;
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var sale in marketManage.ProductSales)
            {
                table.AddRow(sale.No, sale.Price, sale.SaleItems.Count, sale.Date);
            }

            table.Write();
            Console.WriteLine();
            Console.WriteLine("Enter No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Enter Correct No");
                strno = Console.ReadLine();

            }
            Console.WriteLine("Enter Product Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Return Product Count");
            string strcount = Console.ReadLine();
            while (!int.TryParse(strcount, out count))
            {
                Console.WriteLine("Enter Correct Count");
                strcount = Console.ReadLine();
            }
            marketManage.ReturnSale(no, name, count);
        }

        public static void DeleteSales()
        {
            int no = 0;
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var sale in marketManage.ProductSales)
            {
                table.AddRow(sale.No, sale.Price, sale.SaleItems.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Enter Delete No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Enter correct No");
                strno = Console.ReadLine();
            }
            marketManage.DeleteSales(no);
        }

        public static void DisplayAllSales()
        {
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var productSales in marketManage.ProductSales)
            {
                table.AddRow(productSales.No, productSales.Price, productSales.SaleItems.Count, productSales.Date);
            }
            table.Write();
            Console.WriteLine();

        }

        public static void DisplayForDateRangeSales()
        {
            Console.WriteLine("Enter Start Time (dd.mm.yyyy)");
            string strdate1 = Console.ReadLine();
            Console.WriteLine("Enter End Time (dd.mm.yyyy)");
            string strdate2 = Console.ReadLine();
            DateTime date1 = DateTime.Parse(strdate1);
            DateTime date2 = DateTime.Parse(strdate2);
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var sale in marketManage.DisplayDateRangeSale(date1, date2))
            {
                table.AddRow(sale.No, sale.Price, sale.SaleItems.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();

        }

        public static void DisplayForPriceRangeSales()
        {
            double price1 = 0;
            double price2 = 0;
            Console.WriteLine("Enter start price");
            string strprice1 = Console.ReadLine();
            while (!double.TryParse(strprice1, out price1))
            {
                Console.WriteLine("Enter correct Start price");
                strprice1 = Console.ReadLine();
            }
            Console.WriteLine("Enter End price");
            string endprice2 = Console.ReadLine();
            while (!double.TryParse(endprice2, out price2))
            {
                Console.WriteLine("Enter Correct End price");
                endprice2 = Console.ReadLine();
            }
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var sale in marketManage.DisplayMoneyRangeSale(price1, price2))
            {
                table.AddRow(sale.No, sale.Price, sale.SaleItems.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }

        public static void DisplayDateSales()
        {
            Console.WriteLine("Enter Time(dd.mm.yyyy)");
            string strday = Console.ReadLine();
            DateTime day = DateTime.Parse(strday);
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var sale in marketManage.DisplayDateSale(day))
            {
                table.AddRow(sale.No, sale.Price, sale.SaleItems.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }

        public static void DisplaySalesForNo()
        {
            int no = 0;
            Console.WriteLine("Enter No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Enter correct No");
                strno = Console.ReadLine();
            }
            var table = new ConsoleTable("No", "SalePrice", "Count", "Date");
            foreach (var sale in marketManage.DisplayNoSale(no))
            {
                table.AddRow(sale.No, sale.Price, sale.SaleItems.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }














    }
}
#endregion