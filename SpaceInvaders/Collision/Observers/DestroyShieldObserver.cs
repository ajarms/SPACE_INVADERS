using System;

namespace SpaceInvaders
{
    class DestroyShieldObserver : Observer
    {
        public DestroyShieldObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;
            GameObj parent;

            if (pSub.subA is _Shield)
            {
                // remove block & remove columns if needed
                parent = pSub.subA.parent as GameObj;
                pSub.subA.removeMe();
                if (parent.child == null)
                {
                    parent.removeMe();
                }
            }
            else if (pSub.subB is _Shield)
            {
                parent = pSub.subB.parent as GameObj;
                pSub.subB.removeMe();
                if (parent.child == null)
                {
                    parent.removeMe();
                }
            }
        }
    }
}

