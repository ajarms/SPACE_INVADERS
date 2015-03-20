using System;

namespace SpaceInvaders
{
    class ScoreObserver : Observer
    {
        public ScoreObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _Alien ||
                pSub.subA is _UFO)
            {
                ScoreMan.addPoints(pSub.subA);
            }
            else if (pSub.subB is _Alien ||
                     pSub.subB is _UFO)
            {
                ScoreMan.addPoints(pSub.subB);
            }
        }
    }
}
