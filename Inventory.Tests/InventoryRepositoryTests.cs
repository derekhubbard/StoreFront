using System;
using FluentAssertions;
using NUnit.Framework;
using StoreFront.Inventory.Model;

namespace StoreFront.Inventory.Tests
{
    [TestFixture]
    public class InventoryRepositoryTests
    {
        [Test]
        public void GetItem_WhenItemExists_ReturnsItemSuccessfully()
        {
            // arrange
            var inventory = new InventoryRepository();
            
            // act
            Item item = inventory.GetItem("Gold");

            // assert
            item.Name.Should().Be("Gold");
        }

        [Test]
        public void GetItem_WhenItemDoesNotExist_ThrowsInvalidOperationException()
        {
            // arrange
            var inventory = new InventoryRepository();

            // act
            Action act = () => { Item item = inventory.GetItem("ABC"); };

            // assert
            act.ShouldThrow<InvalidOperationException>();
        }
    }
}
