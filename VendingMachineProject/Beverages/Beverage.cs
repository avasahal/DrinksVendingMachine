using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VendingMachineProject.Ingredients;

namespace VendingMachineProject.Beverages
{
    public abstract class Beverage
    {
        
        public string Name { get; set; }
        public double Price { get; set; }
        protected StringBuilder Ingredients { get; set; }
        public List<Ingredient> IngredientList;
        protected int WaterTemperature { get; set; }
        protected int NumberOfStirring { get; set; }
        

        public abstract StringBuilder AddIngredients();
        public abstract string AddWater();
        public abstract string Stirring();

        public async void Prepare(TextBlock msgTxtBlock)
        {
            msgTxtBlock.Text = AddIngredients().ToString();
            await Task.Delay(1500);
            msgTxtBlock.Text += AddWater().ToString();
            await Task.Delay(1500);
            msgTxtBlock.Text += Stirring().ToString();
            await Task.Delay(1500);
            
        }

        //public override string ToString()
        //{
        //    return Ingredients + "\n" + WaterTemperature + "\n" + NumberOfStirring;
        //}
        //public override bool Equals(object obj)
        //{
        //    obj = obj as Beverage;
        //    return this.GetType() == obj.GetType();
        //}
    }
}
