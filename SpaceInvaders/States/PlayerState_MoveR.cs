using System;

namespace SpaceInvaders
{
    class PlayerState_MoveR : State
    {
        public PlayerState_MoveR() : base() { }

        public override void handle(GameObj context)
        {
            if ((context as PlayerRoot).LeftState is PlayerState_NoL)
            {
                (context as PlayerRoot).LeftState = new PlayerState_MoveL();
            }
            context.move(Constants.PLAYER_SPEED, 0.0f);
        }
    }
}
