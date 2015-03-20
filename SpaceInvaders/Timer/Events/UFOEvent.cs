using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    // timed movement event
    class UFOEvent : Event
    {
        public UFOEvent()
            : base()
        { }

        ~UFOEvent()
        {
        }

        public override void execute(float deltaTime)
        {
            UFOFactory.spawnUFO();
            TimerMan.add(Timer.Name.UFOTimer, this, Randomizer.randFloat()*20.0f + 12.0f);
            EventMan.find(Event.Name.UFO_Sound).execute(0.0f);
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
        public Name name = Event.Name.UFO_Spawn;
        public Index index = Index._0;
    }
}
