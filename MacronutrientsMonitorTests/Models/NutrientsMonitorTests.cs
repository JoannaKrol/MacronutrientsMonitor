using MacronutrientsMonitor.Exceptions;
using MacronutrientsMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacronutrientsMonitorTests.Models
{
    public class NutrientsMonitorTests
    {
        public NutrientsMonitor nutrientsMonitor;

        [SetUp]
        public void SetUp() 
        {
            nutrientsMonitor = new NutrientsMonitor();
        }
            

        [Test]
        public void AddDay_WhenAddNewDay_AddTheDayToDaysList()
        {
            //Arrange
            var day = new Day(new DateOnly(2023, 6, 3));

            //Act
            nutrientsMonitor.AddDay(day);

            //Assert
            Assert.That(nutrientsMonitor.GetAllDays().Contains(day), Is.True);
        }

        [Test]
        public void AddDay_WhenAddDayWithDupplicatedId_ThrowExceptionDupplicatedDay()
        {
            //Arrange
            var day = new Day(new DateOnly(2023, 6, 3));

            //Act
            nutrientsMonitor.AddDay(day);

            //Assert
            Assert.Throws<DuplicatedDayException>(() => nutrientsMonitor.AddDay(day),
            $"The day with date {day.Date} has already existed at this content"
            );
        }

        [Test]
        public void AddDay_WhenAddDayWithDupplicatedDate_ThrowExceptionDupplicatedDay()
        {
            //Arrange
            var day = new Day(new DateOnly(2023, 6, 3));
            var day2 = new Day(new DateOnly(2023, 6, 3));

            //Act
            nutrientsMonitor.AddDay(day);

            //Assert
            Assert.Throws<DuplicatedDayException>(() => nutrientsMonitor.AddDay(day2),
            $"The day with date {day2.Date} has already existed at this content"
            );
        }

        [Test]
        public void GetDay_WhenCallTheExistedDaybyId_ReturnCorrectDay()
        {
            //Arrange
            var day = new Day(new DateOnly(2022, 3, 2));

            //Act
            nutrientsMonitor.AddDay(day);
            var gettedDays = nutrientsMonitor.GetDay(day.Id);

            //Assert
            Assert.That(gettedDays, Is.EqualTo(day));
        }

        [Test]
        public void GetDay_WhenCallTheNotExistedDaybyId_ReturnNull()
        {
            //Arrange
            var day = new Day(new DateOnly(2022, 3, 2));

            //Act
            var gettedDays = nutrientsMonitor.GetDay(day.Id);

            //Assert
            Assert.That(gettedDays, Is.Null);
        }
    }
}
