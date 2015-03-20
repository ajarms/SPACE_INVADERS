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
                TempObjMan.add(pSub.subA);
                (GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot) as PlayerRoot).FireState = new PlayerState_CanFire();
                pSub.subA.removeMe();
            }
            else if (pSub.subB is _Missile)
            {
                TempObjMan.add(pSub.subB);
                (GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot) as PlayerRoot).FireState = new PlayerState_CanFire();
                pSub.subB.removeMe();
            }
        }
    }
}
