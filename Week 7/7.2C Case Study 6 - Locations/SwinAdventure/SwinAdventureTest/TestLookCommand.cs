using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SwinAdventureTest
{
    [TestFixture]
    public class TestLookCommand
    {
        LookCommand look;
        Player player;
        Bag bag;
        Item gem;
        Location location;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("bob", "the builder");
            bag = new Bag(new string[] { "bag" }, "bag", "This is a bag");
            gem = new Item(new string[] { "gem" }, "big gem", "an expensive item");
            location = new Location("jungle", "This is a creepy jungle");
        }


        [Test]
        public void TestLookAtMe()
        {
            string actual = look.Execute(player, new string[] { "look", "at", "inventory" });
            string expected = "You are bob, the builder.\nYou are carrying:\n";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGem()
        {
            //player put gem in inventory
            player.Inventory.Put(gem);

            string actual = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "an expensive item";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtUnknown()
        {
            string actual = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "I can't find the gem";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            //look at gem in inventory
            player.Inventory.Put(gem);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" });
            string expected = "an expensive item";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            //put gem in bag, then put bag in player's inventory
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "an expensive item";

            Assert.That(actual, Is.EqualTo(expected));
        }
 
        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the bag";

            Assert.That(actual, Is.EqualTo(expected));
        }

        // test looking at non existent item in your bag
        [Test]
        public void TestLookAtNoGemInBag()
        {
            player.Inventory.Put(bag);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the gem";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPlayerLocation()
        {
            player.Location = location;
            string actual = look.Execute(player, new string[] { "look" });
            Assert.That(actual, Is.EqualTo(location.FullDescription));
        }

        [Test]
        public void TestInvalidLook()
        {
            string actual = look.Execute(player, new string[] { "hello" });
            Assert.That(actual, Is.EqualTo("Error in look input"));
        }

        [Test]
        public void TestInvalidAt()
        {
            string actual = look.Execute(player, new string[] { "look", "in", "gem" });
            Assert.That(actual, Is.EqualTo("What do you want to look at?"));
        }

        [Test]
        public void TestInvalidIn()
        {
            string actual = look.Execute(player, new string[] { "look", "at", "gem", "at", "bag" });
            Assert.That(actual, Is.EqualTo("What do you want to look in?"));
        }

    }
}