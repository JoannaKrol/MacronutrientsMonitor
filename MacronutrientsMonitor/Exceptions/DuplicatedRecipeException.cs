using MacronutrientsMonitor.Models;

namespace MacronutrientsMonitor.Exceptions
{
    public class DuplicatedRecipeException : Exception
    {
        public DuplicatedRecipeException(Recipe recipe) : base($"This recipe has already existed at this content (Id: {recipe.Id}, Name: {recipe.RecipeName} )")
        {

        }
    }
}
