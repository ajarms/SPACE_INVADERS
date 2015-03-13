using System;

namespace SpaceInvaders
{
    class TestObserver: Observer
    {
        public TestObserver()
            : base()
        {
        }

        public override void notify()
        {
            Console.WriteLine("TEST OBSERVER");
        }
    }
}
