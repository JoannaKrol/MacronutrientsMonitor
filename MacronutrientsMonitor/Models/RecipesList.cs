using MacronutrientsMonitor.Exceptions;

namespace MacronutrientsMonitor.Models
{
    public class RecipesList
    {
        private List<Recipe> _recipes;

        public RecipesList()
        {
            _recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            if (_recipes.Any(r => r.Id == recipe.Id || r.RecipeName == recipe.RecipeName))
            {
                throw new DuplicatedRecipeException(recipe);
            }

            _recipes.Add(recipe);
        }
        public Recipe GetRecipe(Guid id) => _recipes.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Recipe> GetAllRecipes() => _recipes;

        public void RemoveRecipe(Guid id)
        {
            _recipes = _recipes.Where(d => d.Id != id).ToList();
        }
    }
}
