using MacronutrientsMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.ViewModels
{
    public class DayViewModel
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        public decimal Fat { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Carbohydrates { get; private set; }
        public int Calories { get; private set; }

        public DayViewModel(Day day)
        {
            Id = day.Id;
            Date = day.Date;

            var summary = day.GetSummary();
            Protein = summary.Protein;
            Fat = summary.Fat;
            Carbohydrates = summary.Carbohydrates;
            Calories = summary.Calories;
        }
    }
}
