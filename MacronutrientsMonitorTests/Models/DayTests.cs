using MacronutrientsMonitor.Exceptions;
using MacronutrientsMonitor.Models;
using NUnit.Framework;

namespace MacronutrientsMonitorTests.Models
{
    public class DayTests
    {
        public Day day;

        [SetUp]
        public void SetUp()
        {
            day = new Day(new DateOnly(2024, 8, 12));
        }

        [Test]
        public void AddDish_WhenAddNewDish_AddDishToDishesList() 
        {
            // Arrange 
            var dish = new Dish("someDish", 22, 50, 8, 600);

            // Act
            day.AddDish(dish);

            // Assert
            Assert.That(day.GetAllDishes().Contains(dish), Is.True);
        }

        [Test]
        public void AddDish_WhenAddManyDishes_AddDishesToDishesLitInCorrectOrder()
        {
            //Arrange
            var dish1 = new Dish("someDish1", 22, 50, 8, 600);
            var dish2 = new Dish("someDish2", 44, 70, 9, 900);
            var dishesList = new List<Dish>
            {
                dish1,
                dish2
            };

            //Act
            day.AddDish(dish1);
            day.AddDish(dish2);

            //Assert
            Assert.That(day.GetAllDishes(), Is.EqualTo(dishesList));
        }

        [TestCase("SomeDish1", 30, 44, 12, 800)]
        [TestCase("SomeDish2", 60, 33, 18, 300)]
        [TestCase("SomeDish3", 10, 60, 5, 400)]
        [TestCase("SomeDish4", 60, 12, 100, 1000)]
        public void AddDish_WhenAddNewDish_UpdateSummary(string dishName, decimal fat, decimal protein, decimal carbohydrates, int calories)
        {
            //Arrange
            var dish = new Dish(dishName, fat, protein, carbohydrates, calories);

            //Act
            day.AddDish(dish);
            var summary = day.GetSummary();

            //Assert
            Assert.That(summary.Fat, Is.EqualTo(dish.Fat));
            Assert.That(summary.Protein, Is.EqualTo(dish.Protein));
            Assert.That(summary.Carbohydrates, Is.EqualTo(dish.Carbohydrates));
            Assert.That(summary.Calories, Is.EqualTo(dish.Calories));
        }

        [Test]
        public void AddDish_WhenAddManyDishes_UpdateSummary()
        {
            //Arrange
            var dish1 = new Dish("someDish1", 22, 50, 8, 600);
            var dish2 = new Dish("someDish2", 44, 70, 9, 900);
            var expectedSummary = new Summary(
                dish1.Fat + dish2.Fat,
                dish1.Protein + dish2.Protein, 
                dish1.Carbohydrates + dish2.Carbohydrates, 
                dish1.Calories + dish2.Calories
            );

            //Act
            day.AddDish(dish1);
            day.AddDish(dish2);
            var summary = day.GetSummary();

            //Assert
            Assert.That(summary.Fat, Is.EqualTo(expectedSummary.Fat));
            Assert.That(summary.Protein, Is.EqualTo(expectedSummary.Protein));
            Assert.That(summary.Carbohydrates, Is.EqualTo(expectedSummary.Carbohydrates));
            Assert.That(summary.Calories, Is.EqualTo(expectedSummary.Calories));
        }

        [Test]
        public void AddDish_WhenAddDuplicatedDish_ThrowDuplicatedDishException()
        {
            //Arrange
            var dish = new Dish("someDish", 22, 50, 8, 600);

            //Act
            day.AddDish(dish);

            //Assert
            Assert.Throws<DuplicatedDishException>(() => day.AddDish(dish),
                $"Dish {dish.DishName} with Id {dish.Id} has already existed at this content"
            );
        }

        [Test]
        public void GetDish_WhenAskExistedDishById_ReturnCorrectDish()
        {
            //Arrange
            var dish = new Dish("someDish", 22, 50, 8, 600);

            //Act
            day.AddDish(dish);
            var gettedDish = day.GetDish(dish.Id);

            //Assert
            Assert.That(gettedDish, Is.EqualTo(dish));
        }

        [Test]
        public void GetDish_WhenAskNotExistedDishById_ReturnNull()
        {
            //Arrange
            var dish = new Dish("someDish", 22, 50, 8, 600);

            //Act
            var gettedDish = day.GetDish(dish.Id);

            //Assert
            Assert.That(gettedDish, Is.Null);
        }

        [Test]
        public void RemoveDish_WhenRemoveExistedDish_RemoveDishFromDishesList()
        {
            //Arrange
            var dish = new Dish("someDish", 22, 50, 8, 600);

            //Act
            day.AddDish(dish);

            //Assert
            Assert.That(day.GetDish(dish.Id), Is.Not.Null);
            
            //Act
            day.RemoveDish(dish.Id);

            //Assert
            Assert.That(day.GetDish(dish.Id), Is.Null);
        }

        [Test]
        public void RemoveDish_WhenRemoveExistedDish_UpdateSummary()
        {
            //Arrange
            var dish1 = new Dish("someDish1", 22, 50, 8, 600);
            var dish2 = new Dish("someDish2", 44, 70, 9, 900);
            var expectedSummary = new Summary(
                dish1.Fat + dish2.Fat,
                dish1.Protein + dish2.Protein,
                dish1.Carbohydrates + dish2.Carbohydrates,
                dish1.Calories + dish2.Calories
            );

            //Act
            day.AddDish(dish1);
            day.AddDish(dish2);
            var summary = day.GetSummary();

            //Assert
            Assert.That(summary.Fat, Is.EqualTo(expectedSummary.Fat));
            Assert.That(summary.Protein, Is.EqualTo(expectedSummary.Protein));
            Assert.That(summary.Carbohydrates, Is.EqualTo(expectedSummary.Carbohydrates));
            Assert.That(summary.Calories, Is.EqualTo(expectedSummary.Calories));

            //Act
            day.RemoveDish(dish1.Id);
            expectedSummary = new Summary(dish2.Fat, dish2.Protein, dish2.Carbohydrates, dish2.Calories);
            summary = day.GetSummary();

            //Assert
            Assert.That(summary.Fat, Is.EqualTo(expectedSummary.Fat));
            Assert.That(summary.Protein, Is.EqualTo(expectedSummary.Protein));
            Assert.That(summary.Carbohydrates, Is.EqualTo(expectedSummary.Carbohydrates));
            Assert.That(summary.Calories, Is.EqualTo(expectedSummary.Calories));

        }
    }
}
