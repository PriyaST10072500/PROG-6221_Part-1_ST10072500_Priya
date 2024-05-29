using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PROG_6221_Part_1_ST10072500_Priya
{
    class Ingredient
    {

        //Gets and Sets the Ingredient's Name
        public string Name { get; set; }


        //Gets and Sets the Ingredient's Quantity
        public double Quantity { get; set; }


        //Gets and Sets the Ingredient's Unit of Measurement  
        public UnitOfMeasurement Unit { get; set; }


        //Gets and Sets the Ingredient's Calories  
        public double Calories { get; set; }


        //Gets and Sets the Ingredient's Food Group
        public FoodGroup FoodGroup { get; set; }


        //Gets and Sets the Ingredient's Original Quantity
        public double OriginalQuantity { get; set; }

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