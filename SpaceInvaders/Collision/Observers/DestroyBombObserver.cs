using System;

namespace SpaceInvaders
{
    class DestroyBombObserver : Observer
    {
        public DestroyBombObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _Bomb)
            {
                TempObjMan.add(pSub.subA);
                (pSub.subA as _Bomb).pSource.State = new ColumnState_CanFire();
                pSub.subA.removeMe();
            }
            else if (pSub.subB is _Bomb)
            {
                TempObjMan.add(pSub.subB);
                (pSub.subB as _Bomb).pSource.State = new ColumnState_CanFire();
                pSub.subB.removeMe();
            }
        }
    }
}
