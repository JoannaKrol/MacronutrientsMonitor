using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Models
{
    public abstract class Macronutrients
    {
        public decimal Fat { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Carbohydrates { get; private set; }
        public int Calories { get; private set; }

        public Macronutrients()
        {
                
        }

        public Macronutrients(decimal fat, decimal protein, decimal carbohydrates, int calories)
        {
            Fat = fat;
            Protein = protein;
            Carbohydrates = carbohydrates;
            Calories = calories;
        }
    }
}
