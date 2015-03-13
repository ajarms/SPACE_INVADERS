using System;

namespace SpaceInvaders
{
    class A_W_Observer: Observer
    {
        public A_W_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Alien hit Wall");
        }
    }
}
