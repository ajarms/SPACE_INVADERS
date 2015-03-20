using System;

namespace SpaceInvaders
{
    class Constants
    {
        public const int SCREEN_HEIGHT  = 1024;
        public const int SCREEN_WIDTH   = 896;
        public const float ALIEN_START_RATE  = 0.5f;
        public const float ALIEN_MIN_RATE    = 0.01f;
        public const float MISSILE_SPEED  = 15.0f;
        public const float BOMB_SPEED = 7.0f;
        public const float PLAYER_SPEED = 4.0f;
        public const float UFO_SPEED = 3.0f;
        public const float GRID_START_X = 128.0f;
        public const float GRID_START_Y = 512.0f;
        public const float GRID_SPACING = 64.0f;
        public static float ALIEN_SPEED()
        {
            return ((Constants.ALIEN_START_RATE - Constants.ALIEN_MIN_RATE) *
                     GObjMan.alienCount() / 55.0f) + Constants.ALIEN_MIN_RATE;
        }
    }
}