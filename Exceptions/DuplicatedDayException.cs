using MacronutrientsMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitor.Exceptions
{
    public class DuplicatedDayException : Exception
    {
        public DuplicatedDayException(Day day) : base($"The day with date {day.Date} has already existed at this content")
        {

        }

    }
}
