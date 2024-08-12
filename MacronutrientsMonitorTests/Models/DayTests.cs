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
    }
}
