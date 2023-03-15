namespace ClockClass
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Clock myClock = new Clock();

            for (int i = 0; i < 260; i++)
            {
                myClock.Tick();
            }
            myClock.Print();
        }
    }
}