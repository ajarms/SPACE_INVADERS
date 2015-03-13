using System;

namespace SpaceInvaders
{
    class M_W_Observer: Observer
    {
        public M_W_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Missile hit Wall");
        }
    }
}
