using ClockClass;
using System.Diagnostics.Metrics;

namespace TestClockClass
{
    [TestFixture]
    public class TestCounter
    {
        Counter myCounter;

        [SetUp]
        public void Setup()
        {
            myCounter = new Counter("counter");
        }

        [Test]
        public void CounterStarts()
        {
            Assert.That(myCounter.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void IncrementCounter()
        {
            myCounter.Increment();
            Assert.That(myCounter.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void IncrementMultiple()
        {
            for (int i = 0; i < 5; i++)
            {
                myCounter.Increment();
            }
            Assert.That(myCounter.Ticks, Is.EqualTo(5));
        }

        [Test]
        public void ResetCounter()
        {
            myCounter.Increment();
            myCounter.Reset();

            Assert.That(myCounter.Ticks, Is.EqualTo(0));
        }
    }


}