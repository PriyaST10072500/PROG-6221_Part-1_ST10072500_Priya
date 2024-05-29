using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_6221_Part_1_ST10072500_Priya
{
     class RecipeManager
     {
        // Using Generic Collections 
        private List<Recipe> recipes = new List<Recipe>();


        // Method that Adds a New Recipe
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }


        // Method that displays all recipes in Alphabetical Order by name
        public void DisplayAllRecipes()
        {
            recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }


        // Method that gets a Recipe by name
        public Recipe GetRecipeByName(string name)
        {
            return recipes.Find(recipe => recipe.Name == name);
        }


        // Method that Clears all recipes
        public void ClearAllRecipes()
        {
            recipes.Clear();
        }

        // Event handler for the recipe that exceeds 300 calories
        public void RecipeExceedsNotification(string recipeName)
        {
            Console.WriteLine($" Warning: Recipe '{recipeName}' exceeds 300 calories!");
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