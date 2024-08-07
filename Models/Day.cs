using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Models
{
    public class Day
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        public List<Dish> DishesList { get; private set; }
        public Summary Summary { get; private set; }

        public Day(DateOnly date)
        {
            Id = Guid.NewGuid();
            Date = date;
            DishesList = new List<Dish>();
            Summary = new Summary();
        }
    }
}
