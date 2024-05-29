using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG_6221_Part_1_ST10072500_Priya.RecipeManager;


namespace PROG_6221_Part_1_ST10072500_Priya
    {
   
        // Delegate that notifies when a recipe exceeds 300 calories
        public delegate void RecipeExceedsCaloriesEventHandler(string recipeName);

        
        // Enumeration for Food Group
        public enum FoodGroup
        {
            Proteins,
            Carbohydrates,
            Fats, 
            Sugars,
            Vegetables,
            Fruits,
            Dairy,
           
        }


        // Enumeration for Units of Measurement
        public enum UnitOfMeasurement
        {
            Teaspoon,
            Tablespoon,
            Cup,
            Milliliter,
            Kilogram
        }


        class Recipe
        {
            public string Name { get; set; }
            public List<Ingredient> Ingredients { get; set; }
            public List<string> Steps { get; set; }



            // Event that notifies when the total calories exceed 300
            public event RecipeExceedsCaloriesEventHandler RecipeExceedsCalories;



            // Method that calculates the total calories of the recipe
            public double CalculateTotalCalories()
            {
                double totalCalories = 0;
                foreach (var ingredient in Ingredients)
                {
                    totalCalories += ingredient.Calories * ingredient.Quantity;
                }
                return totalCalories;
            }



            // Method that display the details of the recipe 
            public void DisplayRecipe()
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($" Recipe: {Name}");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" Ingredients:");
                foreach (var ingredient in Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" Steps:");
                for (int i = 0; i < Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Steps[i]}");
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($" Total Calories: {CalculateTotalCalories()}");

                if (CalculateTotalCalories() > 300)
                {
                    RecipeExceedsCalories?.Invoke(Name);
                }
            }



            // Method that scales the ingredient quantities
            public void ScaleQuantities(double factor)
            {
                foreach (var ingredient in Ingredients)
                {
                    ingredient.Quantity *= factor;
                }
            }



            // Method that resets the ingredient quantities to the original values
            public void ResetQuantities()
            {
                foreach (var ingredient in Ingredients)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity;
                }
            }
        }
}



//References 
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
//https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//https://stackoverflow.com/questions/14792066/change-background-color-on-c-sharp-console-application
//https://www.webstaurantstore.com/guide/582/measurements-and-conversions-guide.html
//https://www.geeksforgeeks.org/console-clear-method-in-c-sharp/
//https://www.geeksforgeeks.org/scale-factor/
//https://stackoverflow.com/questions/52337184/c-getting-user-value-and-resetting-it
//https://stackoverflow.com/questions/13214081/declare-a-generic-collection
//https://www.geeksforgeeks.org/c-sharp-delegates/