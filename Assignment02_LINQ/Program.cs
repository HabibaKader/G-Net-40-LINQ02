using Assignment02_LINQ.Classes;

namespace Assignment02_LINQ
{
    internal class Program
    {
        static List<Product> ProductList = new List<Product>
        {
            new Product { ProductID=1, ProductName="Chai", Category="Beverages", UnitPrice=18, UnitsInStock=39 },
            new Product { ProductID=2, ProductName="Chang", Category="Beverages", UnitPrice=19, UnitsInStock=17 },
            new Product { ProductID=3, ProductName="Aniseed Syrup", Category="Condiments", UnitPrice=10, UnitsInStock=13 },
            new Product { ProductID=4, ProductName="Chef Sauce", Category="Condiments", UnitPrice=22, UnitsInStock=0 },
            new Product { ProductID=5, ProductName="Ikura", Category="Seafood", UnitPrice=31, UnitsInStock=20 },
            new Product { ProductID=6, ProductName="Konbu", Category="Seafood", UnitPrice=6, UnitsInStock=24 },
            new Product { ProductID=7, ProductName="Tofu", Category="Produce", UnitPrice=55, UnitsInStock=5 },
            new Product { ProductID=18, ProductName="Luxury Item", Category="Special", UnitPrice=120, UnitsInStock=2 }
        };
        static void Main(string[] args)
        {
            
        }
    }
}
