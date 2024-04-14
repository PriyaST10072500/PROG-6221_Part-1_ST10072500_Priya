namespace PROG_6221_Part_1_ST10072500_Priya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Displays the Background Colour in Console
            Console.BackgroundColor = ConsoleColor.Magenta;

            //Displays the Text Colour in Console
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            //Displays the Welcome Message
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Welcome to the Recipe Application! ");
            Console.WriteLine("------------------------------------------");


            Recipe recipe = new Recipe();

            //Displays the Menu
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n Menu:");
                Console.WriteLine(" 1. Enter Recipe Details");
                Console.WriteLine(" 2. Display Recipe");
                Console.WriteLine(" 3. Scale Recipe");
                Console.WriteLine(" 4. Reset Quantities");
                Console.WriteLine(" 5. Clear Data");
                Console.WriteLine(" 6. Exit");
                Console.WriteLine("------------------------------------------");
                Console.Write(" Select an option: ");
                string option = Console.ReadLine();
                Console.WriteLine("------------------------------------------");

                switch (option)
                {
                    case "1":
                        recipe.InputRecipeDetails();
                        break;
                    case "2":
                        recipe.RecipeToBeDisplayed();
                        break;
                    case "3":
                        recipe.RecipeToBeScaled();
                        break;
                    case "4":
                        recipe.QuantitiesToBeReset();
                        break;
                    case "5":
                        recipe.DataToBeCleared();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine(" Invalid option! Please select again.");
                        break;
                }
            }

            Console.WriteLine(" Exiting The Recipe Application!");
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

