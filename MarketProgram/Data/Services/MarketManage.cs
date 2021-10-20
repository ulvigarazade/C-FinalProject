using MarketProgram.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketProgram.Data.Common;
using MarketProgram.Data.Enums;

namespace MarketProgram.Data.Services
{
    public class MarketManage : IMarketable
    {
        public List<Products> Product { get; set; }
        public List<ProductSales> ProductSales { get; set; }
        public int Quantity { get;  set; }
        public MarketManage()
        {
            Product = new();
            ProductSales = new();
            
        }
        public int AddProduct(string Name, double ProductPrice, int Quantity,ProductsCategory category)
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Name", "Product's name is empty");
            if (ProductPrice == 0)
                throw new ArgumentOutOfRangeException("ProductPrice", "Product's price is wrong");
            if (ProductPrice < 0)
                throw new ArgumentOutOfRangeException("ProductPrice","Product's price can't less than 0");
            if (Quantity == 0)
                throw new ArgumentOutOfRangeException("Quantity", "Product's count is wrong");
            if (ProductPrice < 1)
                throw new ArgumentOutOfRangeException("Quantity", "Product's count can't less than 0");

            if (category == ProductsCategory.xeta)
                throw new ArgumentNullException("category", "Product's category is wrong");

            Products product = new();
            product.Name = Name;
            product.ProductPrice = ProductPrice;
            product.Quantity = Quantity;
            product.Category = category;
            

            Product.Add(product);
            return product.No;
        }
        public void EditProduct(int Id,string name,double ProductPrice,int Quantity,string category)
        {
           
            var index = Product.FindIndex(x => x.No == Id);
            Product.RemoveAt(index);
            Products products = new();
            products.Name = name;
            products.ProductPrice = ProductPrice;
            //products.Id = newId;
            products.Quantity = Quantity;
            Product.Add(products);                    
        }
        public void DeleteProduct(int key)
        {
            int index = Product.FindIndex(d => d.No == key);
            if (index == -1)
                throw new KeyNotFoundException();
            Product.RemoveAt(index);
        }
        public List<Products> DisplayAllProducts()
        {
            return Product.ToList();
        }
        public List<Products> SearchCategoryForProduct(ProductsCategory category)
        {
            return Product.Where(x => x.Category == category).ToList();

        }
        public List<Products> SearchPriceRangeProduct(int minprice,int maxprice)
        {
            //if (products.Count==0)
            //{
            //    throw new InvalidOperationException("empty list");
            //}
            //int maxprice = int.MinValue;
            var price = Product.FindAll(x => x.ProductPrice >= minprice && x.ProductPrice <= maxprice);

            return price;

        }
        public List<Products> SearchNameForProduct(string productName)
        {
            return Product.Where(i=>i.Name.Contains(productName)).ToList();
        }            

       
        
       
        
       

        public void AddSale(int No, double Price, string SaleItem)
        {
            SaleItem saleItem = new();
            ProductSales productSale = new();
            int index = Product.FindIndex(x => x.No == No);
            if (index == -1)
            {
                throw new ArgumentNullException("Bele mehsul yoxdur");
            }
            var result = Product.ElementAt(index);
            result.Quantity = result.Quantity - Quantity;
            if (result.Quantity < 0)
            {
                throw new ArgumentNullException("Bu qeder mehsul yoxdur");
            }
            double p = (double)(result.ProductPrice * Quantity);
            productSale.Price += p;
            saleItem.Product = result;
            saleItem.Quantity += Product.Count;
            ProductSales.Add(productSale);
            
        }

        public void ReturnSale(int no, string name, int count)
        {
            ProductSales productSales = ProductSales.FirstOrDefault(x => x.No == no);
            if (productSales == null)
            {
                throw new ArgumentNullException("Bele satis movcud deyil");
            }
            SaleItem saleItem = productSales.SaleItems.FirstOrDefault(x => x.Quantity == count);
            Products products = Product.FirstOrDefault(x => x.Name == name);
            if (products == null)
            {
                throw new ArgumentNullException("Bele mehsul yoxdur");
            }
            productSales.SaleItems.Remove(saleItem);
            products.Quantity += Quantity;
            productSales.Price -= products.Quantity * count;
            if (productSales.Price <= -1)
            {
                throw new ArgumentOutOfRangeException("Alinan malin qiymeti qaytarilan malin qiymetinden azdir");

            }
            if (saleItem.Quantity - count <= -1)
            {
                throw new ArgumentNullException("Secilen satisda kifayet qeder mehsul yoxdur");
            }
            productSales.SaleItems.Add(saleItem);
        }
        public void DeleteSales(int no)
        {
            int index = ProductSales.FindIndex(x => x.No == no);
            if (index == -1)
            {
                throw new ArgumentNullException("Bele satis yoxdur");
            }
            ProductSales.RemoveAt(index);
        }     

        public List<ProductSales> DisplayDateRangeSale(DateTime date1, DateTime date2)
        {
            var result = ProductSales.FindAll(x => x.Date >= date1 && x.Date <= date2);
            return result.ToList();
        }

        public List<ProductSales> DisplayDateSale(DateTime Day)
        {
            var result = ProductSales.FindAll(x => x.Date.Day == Day.Day && x.Date.Month == Day.Month && x.Date.Year == Day.Year);
            return result.ToList();
        }

        public List<ProductSales> DisplayMoneyRangeSale(double price1, double price2)
        {
            var result = ProductSales.FindAll(x => x.Price >= price1 && x.Price <= price2);
            return result.ToList();
        }

        public List<ProductSales> DisplayNoSale(int No)
    {
            var result = ProductSales.FindAll(x => x.No == No);
            if (result.Count == 0)
            {
                throw new ArgumentNullException($"{No} nomreli satis yoxdur");
            }
            return result;
        }

        
       
    }
}
