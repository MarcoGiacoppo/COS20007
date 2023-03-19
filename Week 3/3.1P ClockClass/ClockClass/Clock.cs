using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClockClass
{
    public class Clock
    {
        Counter _secs = new Counter("secs");
        Counter _mins = new Counter("mins");
        Counter _hrs = new Counter("hrs");

        public Counter Seconds
        {
            get
            {
                return _secs;
            }
        }
        public Counter Minutes
        {
            get
            {
                return _mins;
            }
        }
        public Counter Hours
        {
            get
            {
                return _hrs;
            }
        }
    


        public void Tick()
        {
            _secs.Increment();
            if(_secs.Ticks > 59)
            {
                _mins.Increment();
                _secs.Reset();
            }
            if(_mins.Ticks > 59)
            {
                _hrs.Increment();
                _mins.Reset();
            }
            if (_hrs.Ticks > 23)
            {
                _hrs.Reset();
                _mins.Reset();
                _secs.Reset();
            }
        }


        public void Print()
        {
            Console.WriteLine("{0}:{1}:{2}", _hrs.Ticks.ToString("00"), _mins.Ticks.ToString("00"), _secs.Ticks.ToString("00"));
        }
    }
}
