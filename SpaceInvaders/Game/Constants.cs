using System;

namespace SpaceInvaders
{
    class Constants
    {
        public const int SCREEN_HEIGHT  = 896;
        public const int SCREEN_WIDTH   = 1024;
        public const float ALIEN_START_RATE  = 0.5f;
        public const float ALIEN_MIN_RATE    = 0.05f;
        public const float MISSILE_SPEED  = 20.0f;
        public const float BOMB_SPEED = 15.0f;
        public const float PLAYER_SPEED = 4.0f;
        public const float UFO_SPEED = 3.0f;
        public static float ALIEN_SPEED()
        {
            return ((Constants.ALIEN_START_RATE - Constants.ALIEN_MIN_RATE) *
                     GObjMan.alienCount() / 55.0f) + Constants.ALIEN_MIN_RATE;
        }
    }
}