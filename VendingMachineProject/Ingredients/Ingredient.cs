using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject.Ingredients
{
    public abstract class Ingredient
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
