using System;

namespace SpaceInvaders
{
    class PlayerState_MoveL : State
    {
        public PlayerState_MoveL() : base() { }

        public override void handle(GameObj context)
        {
            if ((context as PlayerRoot).RightState is PlayerState_NoR)
            {
                (context as PlayerRoot).RightState = new PlayerState_MoveR();
            }
            context.move(Constants.PLAYER_SPEED * -1.0f, 0.0f);
        }
    }
}
