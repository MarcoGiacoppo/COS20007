using Path = SwinAdventure.Path;

namespace SwinAdventureTest
{
	[TestFixture]
	public class TestPath
	{
		Path path;
		Location jungle;

		[SetUp]
		public void Setup()
		{
			jungle = new Location("a jungle", "This is a scary  jungle");
			path = new Path(new string[] { "south", "s" }, "south", "this is south", jungle);
		}

		[Test]
		public void TestPathIsIdentifiable()
		{
			Assert.That(path.AreYou("south"), Is.True);
			Assert.That(path.AreYou("s"), Is.True);
			Assert.That(path.AreYou("north"), Is.False);
		}

		[Test]
		public void TestFullDesc()
		{
			string actual = path.FullDescription;
			string expected = "a jungle is in the south";
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}

