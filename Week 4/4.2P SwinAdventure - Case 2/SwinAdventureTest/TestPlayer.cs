using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventureTest
{
    [TestFixture]
    public class TestPlayer
    {
        Player player;
        Item sword;

        [SetUp]
        public void Setup()
        {
            player = new Player("bob", "the builder");
            sword = new Item(new string[] { "Sword" }, "a golden sword", "This is a golden sword");
            player.Inventory.Put(sword);
        }

        [Test]
        public void TestIsIdentifiable()
        {
            Assert.That(player.AreYou("me"), Is.True);
            Assert.That(player.AreYou("inventory"), Is.True);
        }

        [Test]
        public void TestLocateItems()
        {
            Assert.That(player.Locate("sword"), Is.SameAs(sword));
            Assert.That(player.Inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestLocateItself()
        {
            Assert.That(player.Locate("me"), Is.SameAs(player));
            Assert.That(player.Locate("inventory"), Is.SameAs(player));
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.That(player.Locate("cucumber"), Is.SameAs(null));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(player.FullDescription,
                Is.EqualTo("You are bob, the builder.\nYou are carrying:\na golden sword (sword)\n"));
        }
    }
}
