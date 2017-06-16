using FluentAssertions;
﻿﻿using NUnit.Framework;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.Inventory.Tests.WorthCalculatorRule
{
    [TestFixture]
    public class CadmiumWorthCalculatorRuleTests
    {
        [Test]
        public void Calculate_WhenUpdatingShelfLife_ShouldNotModifyWorth()
        {
            // arrange
            var rule = new CadmiumWorthCalculatorRule();
            const int shelfLife = 10;
            const int originalWorth = 10;

            // act
            int newWorth = rule.Calculate(shelfLife, originalWorth);

            // assert
            newWorth.Should().Be(originalWorth);
        }
    }
}
