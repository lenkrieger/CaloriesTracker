using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calorie_calculator
{
    public class Product // class with all main variables
    {
        public string Name { get; set; }
        public int Calorie { get; set; }
        public int Quantity { get; set; }
        public int TotalCalories => Calorie * Quantity;
    }

    internal class Program
    {
        private static void Main()
        {
            CaloriesTracker tracker = new CaloriesTracker();
            while (true) // safe loop for serving as main manu
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show all Products and summ of calories");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();
                Console.WriteLine("--------------------");
                switch (choice)
                {
                    case "1":
                        AddProducts(tracker);
                        break;

                    case "2":
                        tracker.DisplayProducts();
                        Console.WriteLine("Total Calories: " + tracker.GetTotalCalories());
                        break;

                    case "3":
                        return;
                }
            }
        }

        public class CaloriesTracker
        {
            private List<Product> products = new List<Product>(); // creating new list

            public void AddProduct(string name, int calories, int quantity)
            {
                products.Add(new Product { Name = name, Calorie = calories, Quantity = quantity }); // constructor
            }

            public int GetTotalCalories()
            {
                return products.Sum(p => p.TotalCalories); // all calories summ
            }

            public void DisplayProducts()
            {
                foreach (var product in products)
                {
                    Console.WriteLine(
                        $"{product.Name}: {product.Quantity} servings, {product.TotalCalories} calories total"); // displaying all info for every inst. of list
                }
            }
        }

        private static void AddProducts(CaloriesTracker tracker) // adding new inst. to list
        {
            Console.WriteLine("Input product name:");
            var temName = Console.ReadLine();
            Console.WriteLine("Input calories for 1 product:");
            var temCalorieString = Console.ReadLine();
            int.TryParse(temCalorieString, out var temCalories); // converting string? > to int
            Console.WriteLine("Input product quantity:");
            var temQuantityString = Console.ReadLine();
            int.TryParse(temQuantityString, out var temQuantity);
            tracker.AddProduct(temName, temCalories, temQuantity); //adding product
        }
    }
}