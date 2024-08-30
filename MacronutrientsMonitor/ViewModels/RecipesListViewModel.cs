using MacronutrientsMonitor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacronutrientsMonitor.ViewModels
{
    class RecipesListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Recipe> _recipes;

        public IEnumerable<Recipe> Recipes => _recipes;
        public ICommand AddRecipeCommand { get; }

        public RecipesListViewModel()
        {
            _recipes = new ObservableCollection<Recipe>();
        }
    }
}
