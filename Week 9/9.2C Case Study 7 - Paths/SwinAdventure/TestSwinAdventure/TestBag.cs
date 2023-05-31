using SwinAdventure;

namespace SwinAdventureTest
{
    [TestFixture]
    public class TestBag
    {
        Bag bag;
        Bag backpack;
        Item knife;
        Item sword;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "bag" }, "bag", "This is a big bag");
            backpack = new Bag(new string[] { "backpack" }, "backpack", "This is a cool backpack");

            knife = new Item(new string[] { "Knife" }, "a sharp knife", "This is a sharp knife");
            sword = new Item(new string[] { "Sword" }, "a dull sword", "This is a dull sword");


            bag.Inventory.Put(backpack);
            bag.Inventory.Put(knife);
            backpack.Inventory.Put(sword);
        }


        [Test]
        public void TestLocatesItems()
        {
            Assert.That(bag.Locate("knife"), Is.SameAs(knife));
        }
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(bag.Locate("bag"), Is.SameAs(bag));
        }
        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(bag.Locate("coins"), Is.SameAs(null));
        }
        [Test]
        public void TestFullDescription()
        {
            Assert.That(bag.FullDescription, Is.EqualTo("In the bag you can see:\nbackpack (backpack)\na sharp knife (knife)\n"));
        }
        [Test]
        public void TestBagInBag()
        {
            Assert.That(bag.Locate("backpack"), Is.SameAs(backpack));
            Assert.That(bag.Locate("knife"), Is.SameAs(knife));

            Assert.That(bag.Locate("sword"), Is.SameAs(null));
        }

    }
}
