using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Models
{
    public class Summary : Macronutrients
    {
        public new decimal Fat { get; set; }
        public new decimal Protein { get; set; }
        public new decimal Carbohydrates { get; set; }
        public new int Calories { get; set; }

        public Summary()
        {
            
        }

        public Summary(decimal fat, decimal protein, decimal carbohydrates, int calories) : base(fat, protein, carbohydrates, calories)
        {
        }
    }
}
