using NUnit.Framework;
using NUnit.Framework.Internal;

namespace IdentifiableObjectW
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        IdentifiableObject id;
        IdentifiableObject emptyId;

        [SetUp]
        public void SetUp()
        {
            id = new IdentifiableObject(new string[] { "fred", "bob" });
            emptyId = new IdentifiableObject(new string[] { });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.That(id.AreYou("bob"), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.That(id.Areyou("wilma"), Is.False);
        }
        [Test]
        public void TestCaseSensitive()
        {
            Assert.That(id.AreYou("bOB"), Is.True);
        }
        [Test]
        public void TestFirstId()
        {
            Assert.That(id.FirstId, Is.SameAs("bob"));
        }
        [Test]
        public void TestFirstIdWithNoIds()
        {
            Assert.That(emptyId.FirstId, Is.SameAs(""));
        }
        [Test]
        public void TestAddId()
        {
            id.AddIdentifier("billy");
            Assert.That(id.AreYou("billy"), Is.True);
        }
    }
}
