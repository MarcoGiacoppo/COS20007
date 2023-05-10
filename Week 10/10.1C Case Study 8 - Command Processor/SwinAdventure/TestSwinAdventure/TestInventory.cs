using System;

namespace SwinAdventureTest

{
    [TestFixture]
    public class TestInventory
    {
        Inventory inventory;
        Item sword;
        Item knife;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            sword = new Item(new string[] { "Sword" }, "a gold sword", "This is a gold sword");
            knife = new Item(new string[] { "Knife" }, "a sharp knife", "This is a sharp knife");
            inventory.Put(sword);
            inventory.Put(knife);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.That(inventory.HasItem("sword"), Is.True);
            Assert.That(inventory.HasItem("shovel"), Is.False);
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.That(inventory.HasItem("wrench"), Is.False);
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.That(inventory.Fetch("sword"), Is.SameAs(sword));
            Assert.That(inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.That(inventory.Take("sword"), Is.SameAs(sword));
            Assert.That(inventory.HasItem("sword"), Is.False);
        }

        [Test]
        public void TestItemList()
        {
            Assert.That(inventory.ItemList, Is.EqualTo("a gold sword (sword)\na sharp knife (knife)\n"));
        }
    }
}