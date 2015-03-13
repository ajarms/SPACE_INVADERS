using System;

namespace SpaceInvaders
{
    class DestroyMissileObserver : Observer
    {
        public DestroyMissileObserver()
            : base()
        { }

        public override void notify()
        {
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
