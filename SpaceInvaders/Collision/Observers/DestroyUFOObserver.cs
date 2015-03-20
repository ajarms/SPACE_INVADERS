using System;

namespace SpaceInvaders
{
    class DestroyUFOObserver : Observer
    {
        public DestroyUFOObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _UFO)
            {
                (EventMan.find(Event.Name.UFO_Sound) as SoundEvent).pause();
                TempObjMan.add(pSub.subA);
                pSub.subA.removeMe();
            }
            else if (pSub.subB is _UFO)
            {
                (EventMan.find(Event.Name.UFO_Sound) as SoundEvent).pause();
                TempObjMan.add(pSub.subB);
                pSub.subB.removeMe();
            }
        }
    }
}

