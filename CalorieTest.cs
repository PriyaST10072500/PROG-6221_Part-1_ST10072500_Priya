using System;
using PROG_6221_Part_1_ST10072500_Priya;

namespace Prog_6221_Part_2_UnitTests
{

    [TestClass]
    public class CalorieTest
    {

        [TestMethod]
        public void CaloriesExceedsLimit()
        {
            
                double calorieLimit = 300;
                double initialCalories = 0;
                CaloriesAmount caloriesAmount = new CaloriesAmount(calorieLimit, initialCalories);
                bool eventTriggered = false;


                // CaloriesExceeded event
                caloriesAmount.CaloriesExceeded += (sender, e) => { eventTriggered = true; };


                caloriesAmount.Credit(150);
                Assert.IsFalse(eventTriggered, "Calories are within range, event should not be triggered yet.");

                caloriesAmount.Credit(200);


                // Assert
                Assert.IsTrue(eventTriggered, "Calories Exceeded! event should not be triggered.");
                Assert.AreEqual(350, caloriesAmount.CalTotalAmount, "Total calories should be 350.");

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
