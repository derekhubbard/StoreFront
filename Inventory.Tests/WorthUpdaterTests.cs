using FluentAssertions;
﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using StoreFront.Inventory;
using StoreFront.Inventory.Model;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.InventoryTests
{
    [TestFixture]
    public class WorthUpdaterTests
    {
        [Test]
        public void GetWorthCalculatorRule_ItemHasCustomWorthCalculator_ShouldReturnSpecificItemCalculatorRule()
        {
            // arrange
            var rules = new Dictionary<string, BaseWorthCalculatorRule> {{"ABC", new GoldWorthCalculatorRule()}};
            var worthUpdater = new WorthCalculator(rules);

            // act
            var rule = worthUpdater.GetWorthCalculatorRule("ABC");

            // assert
            rule.GetType().Should().Be(typeof (GoldWorthCalculatorRule));
        }

        [Test]
        public void GetWorthCalculatorRule_ItemUsesDefaultWorthCalculator_ShouldReturnDefaultRule()
        {
            // arrange 
            var worthUpdater = new WorthCalculator(new Dictionary<string, BaseWorthCalculatorRule>());

            // act
            var rule = worthUpdater.GetWorthCalculatorRule("ABC");

            // assert
            rule.GetType().Should().Be(typeof (BaseWorthCalculatorRule));
        }

        [Test]
        public void UpdateWorth_BasicItemWithRemainingShelfLife_ShouldDecreaseWorthByOneEachDay()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
                {
                    Name = "BasicItem",
                    ShelfLife = 10,
                    Worth = originalWorth
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth - 1);
        }

        [Test]
        public void UpdateWorth_BasicItemWithNoShelfLife_ShouldDecreaseWorthByTwoEachDay()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
                {
                    Name = "BasicItem",
                    ShelfLife = 0,
                    Worth = originalWorth
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth - 2);
        }

        [Test]
        public void UpdateWorth_AllItems_ShouldAlwaysHavePositiveWorth()
        {
            // arrange
            var item = new Item()
                {
                    Name = "BasicItem",
                    ShelfLife = 0,
                    Worth = 0
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            Console.WriteLine(string.Format("Name: {0}, ShelfLife: {1}, Worth: {2} ", item.Name, item.ShelfLife, item.Worth));
            item.Worth.Should().BeGreaterOrEqualTo(0);
        }

        // TODO Add positive worth tests for specialty items

        [Test]
        public void UpdateWorth_Gold_ShouldIncreaseInWorthWithAge()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
                {
                    Name = "Gold",
                    ShelfLife = 10,
                    Worth = originalWorth
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth + 1);
        }

        [Test]
        public void UpdateWorth_AllItems_ShouldAlwaysHaveWorthLessThanOrEqualTo50()
        {
            // arrange
            var item = new Item()
                {
                    Name = "Gold",
                    ShelfLife = 10,
                    Worth = 50
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            Console.WriteLine(string.Format("Name: {0}, ShelfLife: {1}, Worth: {2} ", item.Name, item.ShelfLife, item.Worth));
            item.Worth.Should().BeLessOrEqualTo(50);
        }

        // todo add additional tests confirming worth <= 50 for specialty items

        [Test]
        public void UpdateWorth_Cadmium_ShoudlNeverDecreaseInWorth()
        {
            // arrange
            const int originalWorth = 80;
            var item = new Item()
                {
                    Name = "Cadmium",
                    ShelfLife = 10,
                    Worth = originalWorth
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth);
        }

        //[Test]
        //public void UpdateWorth_Helium_ShouldIncreaseWorthByOneWhenShelfLifeGreaterThan10()
        //{
        //    // arrange
        //    const int originalWorth = 10;
        //    var item = new Item()
        //        {
        //            Name = "Helium",
        //            ShelfLife = 11,
        //            Worth = originalWorth
        //        };
        //    var WorthCalculator = new WorthCalculator();

        //    // act
        //    item = WorthCalculator.UpdateWorth(item);

        //    // assert
        //    item.Worth.Should().Be(originalWorth + 1);
        //}

        [Test]
        public void UpdateWorth_Helium_ShouldIncreaseWorthByTwoWhenShelfLifeIs10Days()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
                {
                    Name = "Helium",
                    ShelfLife = 10,
                    Worth = originalWorth
                };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth + 2);
        }

        //[Test]
        //public void UpdateWorth_Helium_ShouldIncreaseWorthByTwoWhenShelfLifeIs6Days()
        //{
        //    // arrange
        //    const int originalWorth = 10;
        //    var item = new Item()
        //    {
        //        Name = "Helium",
        //        ShelfLife = 6,
        //        Worth = originalWorth
        //    };
        //    var WorthCalculator = new WorthCalculator();

        //    // act
        //    item = WorthCalculator.UpdateWorth(item);

        //    // assert
        //    item.Worth.Should().Be(originalWorth + 2);
        //}

        [Test]
        public void UpdateWorth_Helium_ShouldIncreaseWorthByThreeWhenShelfLifeIs5Days()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
            {
                Name = "Helium",
                ShelfLife = 5,
                Worth = originalWorth
            };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth + 3);
        }

        [Test]
        public void UpdateWorth_Helium_ShouldIncreaseWorthByThreeWhenShelfLifeIs1Day()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
            {
                Name = "Helium",
                ShelfLife = 1,
                Worth = originalWorth
            };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth + 3);
        }

        [Test]
        public void UpdateWorth_Helium_ShouldBeZeroWhenShelfLifeIsOver()
        {
            // arrange
            var item = new Item()
            {
                Name = "Helium",
                ShelfLife = 0,
                Worth = 10
            };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(0);
        }

        [Test]
        public void UpdateWorth_Alchemy_ShouldDecreaseByTwoDaysWhenShelfLifeIsPositive()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
            {
                Name = "Alchemy",
                ShelfLife = 10,
                Worth = originalWorth
            };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth - 2);
        }

        [Test]
        public void UpdateWorth_Alchemy_ShouldDecreaseByFourDaysWhenShelfLifeIsPassed()
        {
            // arrange
            const int originalWorth = 10;
            var item = new Item()
            {
                Name = "Alchemy",
                ShelfLife = -2,
                Worth = originalWorth
            };
            var worthUpdater = new WorthCalculator();

            // act
            item = worthUpdater.UpdateWorth(item);

            // assert
            item.Worth.Should().Be(originalWorth - 4);
        }
    }
}
