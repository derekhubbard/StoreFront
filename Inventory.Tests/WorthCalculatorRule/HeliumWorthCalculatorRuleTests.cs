using FluentAssertions;
﻿﻿using NUnit.Framework;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.Inventory.Tests.WorthCalculatorRule
{
    [TestFixture]
    public class HeliumWorthCalculatorRuleTests
    {
        [Test]
        public void Calculate_WhenShelfLifeGreaterThan10_ShouldIncreaseWorthByOne()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 11;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 1);
        }

        [Test]
        public void Calculate_WhenShelfLifeIs10Days_ShouldIncreaseWorthByTwo()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 2);
        }

        [Test]
        public void Calculate_WhenShelfLifeIs6Days_ShouldIncreaseWorthByTwo()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 6;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 2);
        }

        [Test]
        public void Calculate_WhenShelfLifeIs5Days_ShouldIncreaseWorthByThree()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 5;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 3);            
        }

        [Test]
        public void Calculate_WhenShelfLifeIs1Day_ShouldIncreaseWorthByThree()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 1;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 3);                        
        }

        [Test]
        public void Calculate_WhenShelfLifeIsZero_ShouldIncreaseWorthByThree()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 0;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 3);                           
        }

        [Test]
        public void Calculate_WhenShelfLifeIsOver_ShouldReturnWorthOfZero()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = -1;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(0);               
        }

        [Test]
        public void Calculate_WhenIncreasingNetWorth_ShouldNotIncreaseMoreThanMaxWorth()
        {
            // arrange
            var rule = new HeliumWorthCalculatorRule();
            const int shelfLife = 20;
            const int originalWorth = 50;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth);               
        }
    }
}
