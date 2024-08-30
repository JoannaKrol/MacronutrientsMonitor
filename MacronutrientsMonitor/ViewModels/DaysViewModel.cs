using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MacronutrientsMonitor.ViewModels
{
    class DaysViewModel : BaseViewModel
    {
        private readonly ObservableCollection<DayViewModel> _days;

        public IEnumerable<DayViewModel> Days => _days;
        public ICommand AddDayCommand { get; }

        public DaysViewModel()
        {
            _days = new ObservableCollection<DayViewModel>();
        }
    }
}
