using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.Serialization;
using System.Windows.Input;

namespace MacronutrientsMonitor.ViewModels
{
    public class MakeRecipeViewModel : BaseViewModel
    {
        private string _recipeName;
        private decimal _protein;
        private decimal _fat;
        private decimal _carbohydrates;
        private int _calories;
        public string RecipeName 
        { 
            get 
            { 
                return _recipeName; 
            } 
            set
            {
                _recipeName = value;
                OnPropertyChanged(nameof(RecipeName));
            }
        }

        public decimal Protein
        {
            get
            {
                return _protein;
            }
            set
            {
                _protein = value;
                OnPropertyChanged(nameof(Protein));
            }
        }

        public decimal Fat
        {
            get
            {
                return _fat;
            }
            set
            {
                _fat = value;
                OnPropertyChanged(nameof(Fat));
            }
        }

        public decimal Carbohydrates
        {
            get
            {
                return _carbohydrates;
            }
            set
            {
                _carbohydrates = value;
                OnPropertyChanged(nameof(Carbohydrates));
            }
        }

        public int Calories
        {
            get
            {
                return _calories;
            }
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeRecipeViewModel()
        {
                
        }
    }
}
