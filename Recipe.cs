using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_6221_Part_1_ST10072500_Priya
{
    class Recipe
    {
        //Stores the Ingredients 
        private ArrayList ingredients;

        //Stores the Steps 
        private ArrayList steps;

        //Stores the Original Quantities
        private ArrayList originalQuantities;


        //Declaring User Input to Populate the ArrayList 
        public Recipe()
        {
            ingredients = new ArrayList();
            steps = new ArrayList();
            originalQuantities = new ArrayList();
        }


        //User Inputs the Recipe Details 
        public void InputRecipeDetails()
        {
            Console.WriteLine("\n Enter The Details For A Single Recipe");
            Console.WriteLine("------------------------------------------");
            Console.Write(" Number of Ingredients: ");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine(" Invalid Number! Please try again.");
                Console.Write(" Number of Ingredients: ");
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"\n Ingredient {i + 1}:");
                Console.Write(" Name: ");
                string name = Console.ReadLine();

                Console.Write(" Quantity: ");
                double quantity;
                while (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine(" Invalid Quantity! Please try again.");
                    Console.Write(" Quantity: ");
                }

                Console.WriteLine("\n Select unit of measurement:");
                Console.WriteLine(" 1 - tsp (teaspoon)");
                Console.WriteLine(" 2 - tbsp (tablespoon)");
                Console.WriteLine(" 3 - C (cups)");
                Console.WriteLine(" 4 - ml (milliliter)");
                Console.WriteLine(" 5 - kg (kilogram)");
                Console.Write(" Enter option: ");
                string unit = "";
                switch (Console.ReadLine())
                {
                    case "1":
                        unit = "tsp (teaspoon)";
                        break;
                    case "2":
                        unit = "tbsp (tablespoon)";
                        break;
                    case "3":
                        unit = "C (cups)";
                        break;
                    case "4":
                        unit = "ml (milliliter)";
                        break;
                    case "5":
                        unit = "kg (kilogram)";
                        break;
                    default:
                        Console.WriteLine(" Invalid Option! \n Please select another option.");
                        break;
                }


                Ingredient ingredient = new Ingredient(name, quantity, unit);
                ingredients.Add(ingredient);
                originalQuantities.Add(quantity);
            }

            Console.WriteLine("------------------------------------------");
            Console.Write("\n Number of Steps: ");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.WriteLine(" Invalid Number! Please try again.");
                Console.Write(" Number of Steps: ");
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"\n Step {i + 1}:");
                Console.Write(" Description: ");
                string step = Console.ReadLine();
                steps.Add(step);
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n Recipe details entered successfully!");
            Console.WriteLine("------------------------------------------");
        }


        //Displays the Recipe Details
        public void RecipeToBeDisplayed()
        {
            Console.WriteLine("\n Recipe Display");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Ingredients:");
            for (int i = 0; i < ingredients.Count; i++)
            {
                Ingredient ingredient = (Ingredient)ingredients[i];
                Console.WriteLine($" - {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {steps[i]}");
            }
            Console.WriteLine("------------------------------------------");
        }


        //Scales the Recipe
        public void RecipeToBeScaled()
        {
            Console.Write("\n Enter a scaling factor (0,5; 2; or 3): ");
            double factor;
            while (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
            {
                Console.WriteLine(" Invalid Factor! Please select another option 0,5; 2; or 3");
                Console.Write(" Enter a scaling factor: ");
            }

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Recipe scaled successfully!");
            Console.WriteLine("------------------------------------------");
        }


        //Resets the Quantities
        public void QuantitiesToBeReset()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                Ingredient ingredient = (Ingredient)ingredients[i];
                double originalQuantity = (double)originalQuantities[i];
                ingredient.Quantity = originalQuantity;
            }

            Console.WriteLine(" Quantities reset successfully!");
            Console.WriteLine("------------------------------------------");
        }



    }
}
