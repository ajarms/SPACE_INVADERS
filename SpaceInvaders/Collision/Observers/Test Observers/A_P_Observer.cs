using System;

namespace SpaceInvaders
{
    class A_P_Observer: Observer
    {
        public A_P_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Alien hit Player");
        }
    }
}
