using System;

namespace SpaceInvaders
{
    class S_M_Observer: Observer
    {
        public S_M_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Missile hit Shield");
        }
    }
}
