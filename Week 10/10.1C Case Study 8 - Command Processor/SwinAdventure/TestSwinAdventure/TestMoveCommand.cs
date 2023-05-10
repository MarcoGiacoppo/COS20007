using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = SwinAdventure.Path;

namespace SwinAdventureTest
{
    public class TestMoveCommand
    {
        MoveCommand move;
        Location location;
        Location destination;
        Path path;
        Player player;

        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();
            location = new Location("a jungle", "This is a creepy jungle");
            destination = new Location("a tower", "This is a tilted tower");
            path = new Path(new string[] { "south" }, "south", "this is south", destination);
            player = new Player("bob", "the builder");

            player.Location = location;
            location.AddPath(path);
        }

        [Test]
        public void TestMove()
        {
            Assert.That(player.Location, Is.SameAs(location));
            move.Execute(player, new string[] { "move", "south" });
            Assert.That(player.Location, Is.SameAs(destination));
        }

        [Test]
        public void TestInvalidMove()
        {
            Assert.That(player.Location, Is.SameAs(location));
            move.Execute(player, new string[] { "move", "east" });
            Assert.That(player.Location, Is.SameAs(location));
        }

        [Test]
        public void TestSuccessfulMoveOutput()
        {
            string actual = move.Execute(player, new string[] { "move", "south" });
            string expected = "You went south\nYou have arrived in a tower";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //errors

        [Test]
        public void TestIncorrectLength()
        {
            string actual = move.Execute(player, new string[] { "move", "to", "north" });
            string expected = "I don't know how to move like that";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidCommand()
        {
            string actual = move.Execute(player, new string[] { "run", "south" });
            string expected = "Error in move input";

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void TestOnlyMoveInput()
        {
            string actual = move.Execute(player, new string[] { "move" });
            string expected = "Where do you want to move?";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidDirection()
        {
            string actual = move.Execute(player, new string[] { "move", "east" });
            string expected = "Error in direction!";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}