using System;

namespace SpaceInvaders
{
    class A_M_Observer: Observer
    {
        public A_M_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Missile hit Alien");
            Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _Missile)
            {
                pSub.subA.removeMe();
            }
            else if (pSub.subB is _Missile)
            {
                pSub.subB.removeMe();
            }
        }
    }
}
