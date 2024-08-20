using MacronutrientsMonitor.Exceptions;
using MacronutrientsMonitor.Models;

namespace MacronutrientsMonitorTests.Models
{
    public class RecipesListTests
    {
        public RecipesList recipesList;

        [SetUp]
        public void SetUp()
        {
            recipesList = new RecipesList();
        }

        [Test]
        public void AddRecipe_WhenAddRecipe_AddingRecipeToList()
        {
            //Arrange
            var recipe = new Recipe("Scrumbled Eggs", 22, 33, 4, 400);

            //Act
            recipesList.AddRecipe(recipe);

            //Assert
            Assert.That(recipesList.GetAllRecipes().Contains(recipe), Is.True);
        }

        [Test]
        public void AddRecipe_WhenRecipeWithTheSameIdHasAlreadyExisted_ReturnDupplicatedRecipeExveption()
        {
            //Arrange
            var recipe = new Recipe("Scrumbled Eggs", 22, 33, 4, 400);

            //Act
            recipesList.AddRecipe(recipe);

            //Assert
            Assert.Throws<DuplicatedRecipeException>(() => recipesList.AddRecipe(recipe),
                $"This recipe has already existed at this content (Id: {recipe.Id}, Name: {recipe.RecipeName} )"
                );
        }

        [Test]
        public void AddRecipe_WhenRecipeWithTheSameNameHasAlreadyExisted_ReturnDupplicatedRecipeExveption()
        {
            //Arrange
            var recipe = new Recipe("Scrumbled Eggs", 22, 33, 4, 400);
            var recipe2 = new Recipe("Scrumbled Eggs", 40, 38, 60, 800);

            //Act
            recipesList.AddRecipe(recipe);

            //Assert
            Assert.Throws<DuplicatedRecipeException>(() => recipesList.AddRecipe(recipe2),
                $"This recipe has already existed at this content (Id: {recipe2.Id}, Name: {recipe2.RecipeName} )"
                );
        }

        [Test]
        public void GetRecipe_WhenCallExistRecipeById_ReturnRecipe()
        {
            //Arrange
            var recipe = new Recipe("Scrumbled Eggs", 22, 33, 4, 400);

            //Act
            recipesList.AddRecipe(recipe);
            var gettedRecipe = recipesList.GetRecipe(recipe.Id);

            //Assert
            Assert.That(gettedRecipe, Is.EqualTo(recipe));
        }

        [Test]
        public void GetRecipe_WhenCallNotExistRecipeById_ReturnNull()
        {
            //Arrange
            var recipe = new Recipe("Scrumbled Eggs", 22, 33, 4, 400);

            //Act
            var gettedRecipe = recipesList.GetRecipe(recipe.Id);

            //Assert
            Assert.That(gettedRecipe, Is.Null);
        }

        [Test]
        public void RemoveRecipe_WhenRemoveRecipebyId_RemoveRecipeFromList()
        {
            //Arrange 
            var recipe = new Recipe("Scrumbled Eggs", 22, 33, 4, 400);

            //Act
            recipesList.AddRecipe(recipe);
            recipesList.RemoveRecipe(recipe.Id);

            //Assert
            Assert.That(recipesList.GetAllRecipes().Contains(recipe), Is.False);
        }
    }
}
