using SwinAdventure;

namespace SwinAdventureTest
{
    [TestFixture]
    public class TestPlayer
    {
        Player player;
        Item sword;
        Location location;
        Location destination;
        SwinAdventure.Path path;
        Item stone;


        [SetUp]
        public void Setup()
        {
            player = new Player("bob", "the builder");
            sword = new Item(new string[] { "Sword" }, "a golden sword", "This is a golden sword");
            player.Inventory.Put(sword);

            stone = new Item(new string[] { "stone" }, "a stone", "a nice shaped stone");
            location = new Location("jungle", "This is a creepy jungle");
            destination = new Location("a tower", "This is a tower");
            path = new SwinAdventure.Path(new string[] { "south" }, "south", "this is south", destination);
            location.Inventory.Put(stone);
            location.AddPath(path);

            player.Location = location;
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
        public void TestLocateLocation()
        {
            Assert.That(player.Locate("house"), Is.SameAs(location));
        }

        [Test]
        public void TestLocateItemInLocation()
        {
            Assert.That(player.Locate("stone"), Is.SameAs(stone));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(player.FullDescription,
                Is.EqualTo("You are bob, the builder.\nYou are carrying:\na golden sword (sword)\n"));
        }

        [Test]
        public void TestMove()
        {
            player.Move(path);
            Assert.That(player.Location, Is.SameAs(destination));
        }
    }
}
