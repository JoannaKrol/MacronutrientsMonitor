using MacronutrientsMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Exceptions
{
    public class DuplicatedDishException : Exception
    {
        public DuplicatedDishException(Dish dish) : base($"Dish {dish.DishName} with Id {dish.Id} has already existed at this content")
        {

        }
    }
}
