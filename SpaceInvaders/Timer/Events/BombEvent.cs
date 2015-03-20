using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombEvent : Event
    {
        public BombEvent()
            : base()
        { }

        ~BombEvent()
        {
        }

        public override void execute(float deltaTime)
        {
            BombFactory.spawnBomb();
            TimerMan.add(Timer.Name.BombTimer, this, GObjMan.alienCount()*Randomizer.randFloat()/60.0f + 0.05f );
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
        public Name name = Event.Name.Bomb_Spawn;
        public Index index = Index._0;
    }
}
