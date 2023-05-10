using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;
using Path = SwinAdventure.Path;

namespace SwinAdventureTest
{
    [TestFixture]
    public class TestCommandProcessor
    {
        CommandProcessor command;
        Path path1;
        Path path;
        Location location;
        Location destination;
        Item skull;
        Player _player;

        [SetUp]
        public void Setup()
        {
            command = new();
            skull = new Item(new string[] { "Skull"}, "a creepy skull", "This is a creepy skull");
            _player = new Player("Bob", "The builder");
            location = new Location("a jungle", "This is a creepy jungle");
            destination = new Location("a tower", "This is a tilted tower");
            path = new Path(new string[] { "south" }, "south", "this is south", destination);
            //Create destination

            //Create direction
            _player.Location = location;
            location.AddPath(path);
        }

        [Test]
        public void TestLookAtNone()
        {
            string expected = "I can't find the none";
            string actual = command.ExecuteCommand(_player, new string[] { "look", "at", "none" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtInventory()
        {
            string expected = "You are Bob, The builder.\nYou are carrying:\n";
            string actual = command.ExecuteCommand(_player, new string[] { "look", "at", "inventory" });
            Assert.That(actual, Is.EqualTo(expected));
        }
   
        [Test]
        public void TestNoTeach()
        {
            string expected = "I don't know how to teach.";
            string actual = command.ExecuteCommand(_player, new string[] { "teach" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestCantMove()
        {
            string expected = "Error in direction!";
            string actual = command.ExecuteCommand(_player, new string[] { "move", "n" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestCanMoveToLocation()
        {
            string expected = "You have moved north!";
            string actual = command.ExecuteCommand(_player, new string[] { "move", "s" });
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}