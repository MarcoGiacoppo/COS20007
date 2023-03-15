using NUnit.Framework;

namespace TestClockClass
{
    public class TestClock
    {
        Clock myClock;
        [SetUp]
        public void Setup()
        {
            myClock = new Clock();
        }


        [Test]
        public void Tick30s()
        {
            for (int i = 0; i < 30; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Seconds.Ticks, Is.EqualTo(30));
            Assert.That(myClock.Minutes.Ticks, Is.EqualTo(0));
            Assert.That(myClock.Hours.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void Tick60s()
        {
            for (int i = 0; i < 60; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Seconds.Ticks, Is.EqualTo(0));
            Assert.That(myClock.Minutes.Ticks, Is.EqualTo(1));
            Assert.That(myClock.Hours.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void Tick1hr()
        {
            for (int i = 0; i < 3600; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Seconds.Ticks, Is.EqualTo(0));
            Assert.That(myClock.Minutes.Ticks, Is.EqualTo(0));
            Assert.That(myClock.Hours.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void Tick24hrs()
        {
            for (int i = 0; i < 86400; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Seconds.Ticks, Is.EqualTo(0));
            Assert.That(myClock.Minutes.Ticks, Is.EqualTo(0));
            Assert.That(myClock.Hours.Ticks, Is.EqualTo(0));
        }

    }
}
