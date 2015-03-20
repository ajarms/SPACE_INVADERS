using System;

namespace SpaceInvaders
{
    class ColumnState_CanFire : State
    {
        public ColumnState_CanFire() : base() { }

        public override void handle(GameObj context)
        {
            (context as AlienColumn).State = new ColumnState_CantFire();
            BombFactory.dropBomb(context);
        }
    }
}
