using MacronutrientsMonitor.Enums;
using MacronutrientsMonitor.Exceptions;

namespace MacronutrientsMonitor.Models
{
    public class Day
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        private readonly Summary _summary;

        private List<Dish> _dishesList;

        public Day(DateOnly date)
        {
            Id = Guid.NewGuid();
            Date = date;
            _dishesList = new List<Dish>();
            _summary = new Summary();
        }

        public void AddDish(Dish dish)
        {
            if (_dishesList.Any(d => d.Id == dish.Id))
            {
                throw new DuplicatedDishException(dish);
            }

            UpdateSummary(dish, SummaryOperations.Addition);

            _dishesList.Add(dish);
        }

        public Dish GetDish(Guid id) => _dishesList.SingleOrDefault(d => d.Id == id);

        public IEnumerable<Dish> GetAllDishes() => _dishesList;

        public void RemoveDish(Guid id)
        {
            var removedDish = GetDish(id);
            UpdateSummary(removedDish, SummaryOperations.Subtraction);

            _dishesList = _dishesList.Where(d => d.Id != id).ToList();
        }

        public Summary GetSummary() => _summary;

        private void UpdateSummary(Dish dish, SummaryOperations summaryOperations)
        {
            if (summaryOperations == SummaryOperations.Addition)
            {
                _summary.Fat += dish.Fat;
                _summary.Protein += dish.Protein;
                _summary.Carbohydrates += dish.Carbohydrates;
                _summary.Calories += dish.Calories;

            }
            else if (summaryOperations == SummaryOperations.Subtraction)
            {
                _summary.Fat -= dish.Fat;
                _summary.Protein -= dish.Protein;
                _summary.Carbohydrates -= dish.Carbohydrates;
                _summary.Calories -= dish.Calories;
            }
        }
    }
}
