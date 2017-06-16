using FluentAssertions;
﻿﻿﻿using NUnit.Framework;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.Inventory.Tests.WorthCalculatorRule
{
    [TestFixture]
    public class AlchemyWorthCalculatorRuleTests
    {
        [Test]
        public void Calculate_PositiveShelfLife_ShouldReduceWorthByTwo()
        {
            // arrange
            var rule = new AlchemyWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 10;
            
            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth - 2);
        }

        [Test]
        public void Calculate_NegativeShelfLife_ShouldReduceWorthByFour()
        {
            // arrange
            var rule = new AlchemyWorthCalculatorRule();
            const int shelfLife = -10;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth - 4);
        }

        [Test]
        public void Calculate_WhenDecreasingWorth_ShouldNeverDecreaseWorthBelowZero()
        {
            // arrange
            var rule = new AlchemyWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 0;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth);
        }
    }
}
