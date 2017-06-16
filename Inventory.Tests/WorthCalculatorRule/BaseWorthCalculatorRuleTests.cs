using FluentAssertions;
﻿﻿﻿using NUnit.Framework;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.Inventory.Tests.WorthCalculatorRule
{
    [TestFixture]
    public class BaseWorthCalculatorRuleTests
    {
        [Test]
        public void Caculate_WhenPositiveShelfLife_ShouldDecreaseWorthByOne()
        {
            // arrange
            var rule = new BaseWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth - 1);
        }

        [Test]
        public void Calculate_WhenZeroShelfLife_ShouldDecreaseWorthByOne()
        {
            // arrange
            var rule = new BaseWorthCalculatorRule();
            const int shelfLife = 0;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth - 1);
        }

        [Test]
        public void Calculate_WhenNegativeShelfLife_ShouldDecreaseWorthByTwo()
        {
            // arrange
            var rule = new BaseWorthCalculatorRule();
            const int shelfLife = -1;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth - 2);
        }

        [Test]
        public void Calculate_WhenDecreasingWorth_ShouldNotDecreaseWorthBelowZero()
        {
            // arrange
            var rule = new BaseWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 0;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth);            
        }
    }
}
