using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public string Unit { get; set; }

        
        //Parameterised Constructor for Dependencies 
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }


    }
}
