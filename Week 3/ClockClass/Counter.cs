using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockClass
{
    public class Counter
    {
        private int _count;
        private string _name;

        

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public int Ticks
        {
            get
            {
                return _count;
            }
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
