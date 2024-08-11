using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Models
{
    public class Recipe : Macronutrients
    {
        public Guid Id { get; private set; }
        public string DishName { get; private set; }

        public Recipe(string dishName, decimal fat, decimal protein, decimal carbohydrates, int calories) : base(fat, protein, carbohydrates, calories)
        {
            Id = Guid.NewGuid();
            DishName = dishName;
        }
    }
}
