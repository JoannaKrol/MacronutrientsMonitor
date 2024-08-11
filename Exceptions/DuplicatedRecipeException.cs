using MacronutrientsMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Exceptions
{
    public class DuplicatedRecipeException : Exception
    {
        public DuplicatedRecipeException(Recipe recipe) : base($"This recipe has already existed at this content (Id: {recipe.Id}, Name: {recipe.DishName} )")
        {

        }
    }
}
