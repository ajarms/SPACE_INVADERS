using System;

namespace SpaceInvaders
{
    class U_M_Observer: Observer
    {
        public U_M_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Missile hit UFO");
        }
    }
}
