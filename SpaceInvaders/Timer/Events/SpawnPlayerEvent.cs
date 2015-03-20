using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpawnPlayerEvent : Event
    {
        public SpawnPlayerEvent()
            : base()
        {
        }

        ~SpawnPlayerEvent()
        {
        }

        public override void execute(float deltaTime)
        {
            // remove death animation
            TimerMan.remove(Timer.Name.DeathAnimationTimer);
            PlayerFactory.spawnPlayer();
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-----------------------
        public Name name = Event.Name.Player_Spawn;
        public Index index = Index._0;
    }
}
