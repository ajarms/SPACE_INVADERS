using System;

namespace SpaceInvaders
{
    class PlayerWallObserver: Observer
    {
        public PlayerWallObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _Wall)
            {
                // which wall is it?
                if (pSub.subA is WallRight)
                {
                    (pSub.subB.parent as PlayerRoot).RightState = new PlayerState_NoR();
                }
                else if (pSub.subA is WallLeft)
                {
                    (pSub.subB.parent as PlayerRoot).LeftState = new PlayerState_NoL();
                }
            }
            else if (pSub.subB is _Wall)
            {

                // which wall is it?
                if (pSub.subB is WallRight)
                {
                    (pSub.subA.parent as PlayerRoot).RightState = new PlayerState_NoR();
                }
                else if (pSub.subB.parent is WallLeft)
                {
                    (pSub.subA as PlayerRoot).LeftState = new PlayerState_NoL();
                }
            }
        }
    }
}
