using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Models
{
    public class Summary : Macronutrients
    {
        public Summary()
        {
            
        }

        public Summary(decimal fat, decimal protein, decimal carbohydrates, int calories) : base(fat, protein, carbohydrates, calories)
        {
        }
    }
}
