using MacronutrientsMonitor.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Models
{
    public class NutrientsMonitor
    {
        private readonly List<Day> _days;

        public NutrientsMonitor()
        {
            _days = new List<Day>();
        }

        public void AddDay(Day day) 
        {
            if (_days.Any(d => d.Id == day.Id || d.Date == day.Date))
            {
                throw new DuplicatedDayException(day);
            }

            _days.Add(day);
        }

        public Day GetDay(Guid id) => _days.Single(d => d.Id == id);

        public IEnumerable<Day> GetAllDays() => _days;
    }
}
