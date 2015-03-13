using System;

namespace SpaceInvaders
{
    class P_B_Observer: Observer
    {
        public P_B_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Bomb hit Player");
        }
    }
}
