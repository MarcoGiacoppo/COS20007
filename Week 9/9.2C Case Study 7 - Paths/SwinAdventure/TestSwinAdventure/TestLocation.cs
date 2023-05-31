using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SwinAdventureTest
{
	public class TestLocation
	{
		Location location;
		Location destination;
        SwinAdventure.Path path;
		Player player;
		Item knife;

		[SetUp]
		public void Setup()
		{
			location = new Location("a jungle", "This is a jungle");
			destination = new Location("a tower", "This is a tilted tower");
			path = new SwinAdventure.Path(new string[] { "south" }, "south", "this is south", destination);
			player = new Player("bob", "the builder");
			knife = new Item(new string[] { "Knife" }, "a sharp knife", "This is a sharp knife");

			location.Inventory.Put(knife);
			player.Location = location;
		}

		[Test]
		public void TestIdentifyLocation()
		{
			Assert.That(location.Locate("house"), Is.SameAs(location));
		}

		[Test]
		public void TestIdentifyLocationInventory()
		{
			Assert.That(location.Locate("knife"), Is.SameAs(knife));
		}

		[Test]
		public void TestIdentifyPlayerLocateItem()
		{
			Assert.That(player.Locate("knife"), Is.SameAs(knife));
		}

		[Test]
		public void TestLocationFullDesc()
		{
			location.AddPath(path);
			string expected = "You are in a jungle\nThis is a jungle\nThere is an exit south.\nHere you can see:\na sharp knife (knife)\n";
			Assert.That(location.FullDescription, Is.EqualTo(expected));
		}
	}
}

