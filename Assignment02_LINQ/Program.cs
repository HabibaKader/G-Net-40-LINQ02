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

        static List<Customer> Customers = new List<Customer>
        {
            new Customer { CustomerID="C1", CompanyName="ABC Co", Country="Germany",
                Orders = new List<Order> {
                    new Order{OrderID=1, Total=100},
                    new Order{OrderID=2, Total=200}
                }
            },
            new Customer { CustomerID="C2", CompanyName="XYZ Ltd", Country="France",
                Orders = new List<Order> {
                    new Order{OrderID=3, Total=300}
                }
            },
            new Customer { CustomerID="C3", CompanyName="Tech Corp", Country="Germany",
                Orders = new List<Order> {
                    new Order{OrderID=4, Total=150}
                }
            }
        };
        static void Main(string[] args)
        {
            #region Question01
            var result = ProductList .OrderByDescending(p => p.UnitPrice)
                                     .Take(3);

            foreach (var p in result) Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion

            #region Question02
            var page = ProductList.Skip(5)
                                  .Take(5);

            foreach (var p in page) Console.WriteLine(p.ProductName);
            #endregion

            #region Question03
            var resultt = ProductList.OrderBy(p => p.UnitPrice)
                                     .TakeWhile(p => p.UnitPrice < 25);

            foreach (var p in resultt) Console.WriteLine(p.ProductName);
            #endregion

            #region Question04
            bool res = ProductList.Where(p => p.Category == "Seafood")
                                  .All(p => p.UnitsInStock > 0);

            Console.WriteLine(res);
            #endregion

            #region Question05
            int[] ids = { 3, 9, 13, 18 };

            bool resulttt = ids.Contains(9);

            Console.WriteLine(resulttt);
            #endregion

            #region Question06
            var groups = ProductList.GroupBy(p => p.Category);

            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Key} - Count: {g.Count()}");
            }
            #endregion

            #region Question07
            var ggroups = ProductList
                                    .GroupBy(p => p.Category)
                                    .Select(g => new
                                    {
                                        Category = g.Key,
                                        Names = g.Select(p => p.ProductName)
                                    });

            foreach (var g in ggroups)
            {
                Console.WriteLine(g.Category);
                foreach (var name in g.Names)
                    Console.WriteLine($" - {name}");
            }
            #endregion

            #region Question08
            var output = ProductList
                                    .GroupBy(p => p.Category)
                                    .Where(g => g.Count() > 3)
                                    .Select(g => g.Key);

            foreach (var c in output) Console.WriteLine(c);
            #endregion

            #region Question09
            var Result =
                        from c in Customers
                        group c by c.Country into g
                        select new
                        {
                            Country = g.Key,
                            Count = g.Count(),
                            TotalOrderValue = g.SelectMany(c => c.Orders).Sum(o => o.Total)
                        };

            foreach (var item in Result)
            {
                Console.WriteLine($"{item.Country} - {item.Count} - {item.TotalOrderValue}");
            }
            #endregion

            #region Question10
            int total = ProductList.Sum(p => p.UnitsInStock);

            Console.WriteLine(total);
            #endregion

            #region Question11
            var min = ProductList.Min(p => p.UnitPrice);
            var max = ProductList.Max(p => p.UnitPrice);

            Console.WriteLine($"Min: {min}, Max: {max}");
            #endregion

            #region Question12
            var categories = ProductList
                                        .Select(p => p.Category)
                                        .Distinct();

            foreach (var c in categories) Console.WriteLine(c);
            #endregion

            #region Question13
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var r = setA.Except(setB);

            foreach (var x in r)
                Console.WriteLine(x);
            #endregion

            #region Question14
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var rr = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

            foreach (var c in rr) Console.WriteLine(c);
            #endregion
        }
    }
}
