using System;

namespace SpaceInvaders
{
    abstract class Event: MLink
    {
        public enum Name
        {
            Crab_Animation,
            Octopus_Animation,
            Squid_Animation,
            Grid_Movement,
            BombA_Animation,
            BombB_Animation,
            BombC_Animation,
            Death_Animation,
            UFO_Spawn,
            Player_Spawn,
            Alien_Spawn,
            Stop_Explosion,
            Bomb_Spawn,

            Alien_SoundA,
            Alien_SoundB,
            Alien_SoundC,
            Alien_SoundD,
            Shoot_Sound,
            UFO_Sound,
            UFODeath_Sound,
            Explosion_Sound,
            Death_Sound,

            NOT_INITIALIZED
        }

        public enum Type
        {
            Animation,
            NOT_INITIALIZED
        }

        public Event()
            : base()
        {
        }

        abstract public void execute(float deltaTime);
    }
}