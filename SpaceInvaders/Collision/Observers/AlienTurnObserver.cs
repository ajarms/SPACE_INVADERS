using System;

namespace SpaceInvaders
{
    class AlienTurnObserver: Observer
    {
        public AlienTurnObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;
            AlienRoot pGrid;

            if (pSub.subA is _Alien)
            {
                pGrid = pSub.subA as AlienRoot;
                pGrid.changeDirection();
                pGrid.move(10.0f, -9.0f);
            }
            else if (pSub.subB is _Alien)
            {
                pGrid = pSub.subA as AlienRoot;
                pGrid.changeDirection();
                pGrid.move(8.0f, -9.0f);
            }
        }
    }
}
