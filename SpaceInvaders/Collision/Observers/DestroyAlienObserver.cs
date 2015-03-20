using System;

namespace SpaceInvaders
{
    class DestroyAlienObserver: Observer
    {
        public DestroyAlienObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;
            GameObj parent;

            if (pSub.subA is _Alien)
            {
                // remove alien & remove columns if needed
                parent = pSub.subA.parent as GameObj;
                pSub.subA.removeMe();
                if (parent.child == null)
                {
                    (parent.parent as AlienRoot).updateColumnCount();
                    parent.removeMe();
                }
                EventMan.find(Event.Name.Explosion_Sound).execute(0.0f);
            }
            else if (pSub.subB is _Alien)
            {
                parent = pSub.subB.parent as GameObj;
                pSub.subB.removeMe();
                if (parent.child == null)
                {
                    parent.removeMe();
                }
                EventMan.find(Event.Name.Explosion_Sound).execute(0.0f);
            }
            GObjMan.updateAlienCount();
        }
    }
}
