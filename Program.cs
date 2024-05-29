using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PROG_6221_Part_1_ST10072500_Priya
{
    class Program
    {
        static void Main(string[] args)
        {
            // Change the Background Colour of the Console Application
            Console.BackgroundColor = ConsoleColor.Magenta;

            // Change the Text Colour of the Console Application
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Welcome to the Recipe Application!");
            Console.WriteLine("------------------------------------------");

            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("\n Menu:");
                Console.WriteLine(" 1. Add Recipe");
                Console.WriteLine(" 2. Display Recipe");
                Console.WriteLine(" 3. Scale Recipe");
                Console.WriteLine(" 4. Reset Quantities");
                Console.WriteLine(" 5. Clear Data");
                Console.WriteLine(" 6. Exit");
                Console.WriteLine("------------------------------------------");
                Console.Write(" Select an option: ");


                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine(" Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddRecipe(recipeManager);
                        break;
                    case 2:
                        DisplayRecipe(recipeManager);
                        break;
                    case 3:
                        ScaleRecipe(recipeManager);
                        break;
                    case 4:
                        ResetQuantities(recipeManager);
                        break;
                    case 5:
                        recipeManager.ClearAllRecipes();
                        Console.WriteLine(" All data cleared.");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" Invalid choice. Please try again.");
                        break;
                }
            }
        }



        // Method that Adds a new recipe
        static void AddRecipe(RecipeManager recipeManager)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n Enter the details for a Recipe: ");
            Recipe newRecipe = new Recipe();
            Console.WriteLine("------------------------------------------");
            Console.Write(" Name of Recipe: ");
            newRecipe.Name = Console.ReadLine();


            newRecipe.Ingredients = new List<Ingredient>();
            Console.Write(" Number of Ingredients: ");
            int numIngredients;
            if (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine(" Invalid input. Please enter a positive integer.");
                return;
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("------------------------------------------");
                Ingredient ingredient = new Ingredient();
                Console.Write($"\n Name of ingredient {i + 1}: ");
                ingredient.Name = Console.ReadLine();

                Console.WriteLine("------------------------------------------");
                Console.Write($" Quantity of {ingredient.Name}: ");
                double quantity;
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine(" Invalid input. Please enter a positive number.");
                    return;
                }
                ingredient.Quantity = quantity;
                ingredient.OriginalQuantity = quantity;


                // Switch Case for the Unit of Measurements
                Console.WriteLine("\n Select unit of measurement:");
                Console.WriteLine(" 1 - tsp (teaspoon)");
                Console.WriteLine(" 2 - tbsp (tablespoon)");
                Console.WriteLine(" 3 - C (cups)");
                Console.WriteLine(" 4 - ml (milliliter)");
                Console.WriteLine(" 5 - kg (kilogram)");
                Console.Write(" Enter option: ");
                int unitChoice;
                if (!int.TryParse(Console.ReadLine(), out unitChoice) || unitChoice < 1 || unitChoice > 5)
                {
                    Console.WriteLine(" Invalid input. Please enter a number between 1 and 5.");
                    return;
                }

                switch (unitChoice)
                {
                    case 1:
                        ingredient.Unit = UnitOfMeasurement.Teaspoon;
                        break;
                    case 2:
                        ingredient.Unit = UnitOfMeasurement.Tablespoon;
                        break;
                    case 3:
                        ingredient.Unit = UnitOfMeasurement.Cup;
                        break;
                    case 4:
                        ingredient.Unit = UnitOfMeasurement.Milliliter;
                        break;
                    case 5:
                        ingredient.Unit = UnitOfMeasurement.Kilogram;
                        break;
                }

                Console.WriteLine("------------------------------------------");
                Console.Write($"\n Enter calories per unit of {ingredient.Name}: ");
                double calories;
                if (!double.TryParse(Console.ReadLine(), out calories) || calories <= 0)
                {
                    Console.WriteLine(" Invalid input. Please enter a positive number.");
                    return;
                }
                ingredient.Calories = calories;


                // Switch Case for the Food Groups
                Console.WriteLine("\n Select food group:");
                Console.WriteLine(" 1. Proteins");
                Console.WriteLine(" 2. Carbohydrates");
                Console.WriteLine(" 3. Fat & Sugars");
                Console.WriteLine(" 4. Dairy");
                Console.WriteLine(" 5. Fruit & Vegetables");
                Console.Write(" Enter choice: ");
                int foodGroupChoice;
                if (!int.TryParse(Console.ReadLine(), out foodGroupChoice) || foodGroupChoice < 1 || foodGroupChoice > 7)
                {
                    Console.WriteLine(" Invalid input. Please enter a number between 1 and 7.");
                    return;
                }

                switch (foodGroupChoice)
                {
                    case 1:
                        ingredient.FoodGroup = FoodGroup.Proteins;
                        break;
                    case 2:
                        ingredient.FoodGroup = FoodGroup.Carbohydrates;
                        break;
                    case 3:
                        ingredient.FoodGroup = FoodGroup.Fats;
                        break;
                    case 4:
                        ingredient.FoodGroup = FoodGroup.Vegetables;
                        break;
                    case 5:
                        ingredient.FoodGroup = FoodGroup.Fruits;
                        break;
                    case 6:
                        ingredient.FoodGroup = FoodGroup.Dairy;
                        break;
                    
                }

                newRecipe.Ingredients.Add(ingredient);
            }

            Console.WriteLine("------------------------------------------");
            newRecipe.Steps = new List<string>();
            Console.Write("\n Enter the number of steps: ");
            int numSteps;
            if (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.WriteLine(" Invalid input. Please enter a positive integer.");
                return;
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($" Enter description for step {i + 1}: ");
                newRecipe.Steps.Add(Console.ReadLine());
            }

            newRecipe.RecipeExceedsCalories += recipeManager.RecipeExceedsNotification;
            recipeManager.AddRecipe(newRecipe);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Recipe details entered successfully!");
            Console.WriteLine("------------------------------------------");
        }

        // Method to display a recipe
        static void DisplayRecipe(RecipeManager recipeManager)
        {
            Console.Write("\n Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipeManager.GetRecipeByName(recipeName);
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine(" Recipe not found!");
            }
        }


        // Method to scale a recipe
        static void ScaleRecipe(RecipeManager recipeManager)
        {
            Console.Write("\n Enter the name of the recipe to scale:");
            string selectedRecipeName = Console.ReadLine();
            Recipe selectedRecipe = recipeManager.GetRecipeByName(selectedRecipeName);
            if (selectedRecipe != null)
            {
                Console.Write(" Enter a scaling factor (0,5; 2; 3):");
                double factor;
                if (!double.TryParse(Console.ReadLine(), out factor) || factor <= 0)
                {
                    Console.WriteLine(" Invalid input. Please enter a positive number.");
                    return;
                }

                selectedRecipe.ScaleQuantities(factor);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" Recipe scaled successfully!");
                Console.WriteLine("------------------------------------------");
            }
            else
            {
                Console.WriteLine(" Recipe not found!");
            }
        }

        // Method to reset ingredient quantities
        static void ResetQuantities(RecipeManager recipeManager)
        {
            Console.Write("\n Enter the name of the recipe to reset quantities:");
            string selectedRecipeName = Console.ReadLine();
            Recipe selectedRecipe = recipeManager.GetRecipeByName(selectedRecipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetQuantities();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" Quantities reset successfully!");
                Console.WriteLine("------------------------------------------");
            }
            else
            {
                Console.WriteLine(" Recipe not found!");
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

