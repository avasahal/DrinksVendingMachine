using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineProject.Ingredients;

namespace VendingMachineProject.Beverages
{
    class Tea : Beverage
    {

        public Tea()
        {
            Price = 4.00;
            IngredientList = new List<Ingredient>
            {
                new Cup(),
                new Sugar(),
                new TeaLeaves()
            };
            WaterTemperature = 100;
            NumberOfStirring = 2;


        }
        public override StringBuilder AddIngredients()
        {
            Ingredients = new StringBuilder();

            foreach (var ingredient in IngredientList)
            {
                Ingredients.Append("Adding " + ingredient.Name + "\n");
            }
            return Ingredients;
        }

        public override string AddWater()
        {
            return ("Adding water with temperature: " + WaterTemperature + "C\n");
        }

        public override string Stirring()
        {
            return ("Stirring the beverage " + NumberOfStirring + " times");
        }

        //public override string ToString()
        //{
        //    return Ingredients + "\n" + WaterTemperature + "\n" + NumberOfStirring;
        //}
        //public override bool Equals(object obj)
        //{
        //    obj = obj as Tea;
        //    return this.GetType() == obj.GetType();
        //}

    }
}
