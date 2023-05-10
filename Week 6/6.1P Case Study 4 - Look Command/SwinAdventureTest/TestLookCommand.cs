using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestLookCommand
    {
        LookCommand look;
        Player player;
        Bag bag;
        Item gem;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("bob", "the builder");
            bag = new Bag(new string[] { "bag" }, "bag", "This is a bag");
            gem = new Item(new string[] { "gem" }, "big gem", "an expensive item");
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
        public void TestInvalidLook()
        {
            string actual = look.Execute(player, new string[] { "look", "around" });
            Assert.That(actual, Is.EqualTo("I don't know how to look like that"));

            string expected = look.Execute(player, new string[] { "hello" });
            Assert.That(expected, Is.EqualTo("I don't know how to look like that"));

            string command1 = look.Execute(player, new string[] { "look", "at", "a", "at", "b" });
            Assert.That(command1, Is.EqualTo("What do you want to look in?"));

            string command3 = look.Execute(player, new string[] { "hello", "at", "a" });
            Assert.That(command3, Is.EqualTo("Error in look input"));

            string command4 = look.Execute(player, new string[] { "look", "by", "a" });
            Assert.That(command4, Is.EqualTo("What do you want to look at?"));
        }



    }
}