using FluentAssertions;
﻿﻿using NUnit.Framework;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.Inventory.Tests.WorthCalculatorRule
{
    [TestFixture]
    public class GoldWorthCalculatorRuleTests
    {
        [Test]
        public void Calculate_PositveShelfLife_IncreasesWorth()
        {
            // arrange
            var calculator = new GoldWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 10;
            
            // act
            int newWorth = calculator.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth + 1);
        }

        [Test]
        public void Calculate_WhenIncreasingWorth_ShouldNotIncreaseMoreThanMaxWorth()
        {
            // arrange
            var calculator = new GoldWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 50;

            // act
            int newWorth = calculator.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth);
        }
    }
}
