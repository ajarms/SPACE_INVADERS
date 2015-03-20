using System;

namespace SpaceInvaders
{
    class PlayerState_CanFire: State
    {
        public PlayerState_CanFire() : base() { }

        public override void handle(GameObj context)
        {
            (context as PlayerRoot).FireState = new PlayerState_CantFire();
            MissileFactory.fireMissile(context);
            EventMan.find(Event.Name.Shoot_Sound).execute(0.0f);
        }
    }
}
