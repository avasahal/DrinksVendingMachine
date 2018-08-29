using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineProject.Beverages;
using VendingMachineProject.Ingredients;

namespace VendingMachineProject.Manager
{
    public class ProductManager
    {
        //private static Dictionary<Ingredient, int> ingredientsProductDictionnary = new Dictionary<Ingredient, int>();
        private static List<Ingredient> ingredientList = new List<Ingredient>();

        static ProductManager()
        {

            //ingredientsProductDictionnary.Add(new Cup(), 5);
            //ingredientsProductDictionnary.Add(new Sugar(), 4);
            //ingredientsProductDictionnary.Add(new Milk(), 5);
            //ingredientsProductDictionnary.Add(new CoffeeBeans(), 2);
            //ingredientsProductDictionnary.Add(new ChocolatePowder(), 3);
            //ingredientsProductDictionnary.Add(new TeaLeaves(), 1);

            ingredientList.Add(new Cup());
            ingredientList.Add(new Sugar());
            ingredientList.Add(new Milk());
            ingredientList.Add(new CoffeeBeans());
            ingredientList.Add(new ChocolatePowder());
            ingredientList.Add(new TeaLeaves());
        }


        // this function is used to check wheter all the ingredients for the beverage chosen are available
        public bool CheckIngredientsAvailability(Beverage beverage)
        {
            foreach (var beverageIngredients in beverage.IngredientList)
            {
                foreach (var productIngredients in ingredientList)
                {
                    if(productIngredients.Name == beverageIngredients.Name)
                    {
                        if(productIngredients.Amount <= 0)
                        {
                            return false;
                        }
                    }  
                }
            }
            return true;
        }


        // this function is used to manage the product ingredients as the user selects and buys a product
        public void IngredientsSupply(Beverage beverage)
        {
            foreach (var beverageIngredients in beverage.IngredientList)
            {
                foreach (var ingredientsSupply in ingredientList)
                {
                    if (ingredientsSupply.Name == beverageIngredients.Name)
                    {
                        ingredientsSupply.Amount --;
                        //ingredientList[ingredientsSupply.Amount]--;
                        break;
                    }
                }
            }
        }
    }
}
