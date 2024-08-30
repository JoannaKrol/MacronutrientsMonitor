using MacronutrientsMonitor.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MacronutrientsMonitor.ViewModels
{
    class DaySummaryViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Dish> _dishes;

        public IEnumerable<Dish> Dishes => _dishes;
        public ICommand AddDishCommand { get; }

        public DaySummaryViewModel()
        {
            _dishes = new ObservableCollection<Dish>();
            _dishes.Add(new Dish("fish and chips", 100, 2, 130, 1000)); //test 
        }
    }
}
