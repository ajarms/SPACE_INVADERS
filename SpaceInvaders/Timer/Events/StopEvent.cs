using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    // finds a recurring event on the timer and removes it
    class StopEvent: Event
    {
        public StopEvent(Index _index)
            : base()
        {
            this.target = null;
            this.index = _index;
            //this.free = true;
        }

        ~StopEvent()
        {
        }

        public void set(GameObj toStop)
        {
            this.target = toStop;
            //this.free = false;
        }

        public override void execute(float deltaTime)
        {
            this.target.drawSprite.batchRemove();
            TempObjMan.add(target);
            //this.free = true;
            EventMan.add(this);
            //this.target = null;
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
        public Name name = Event.Name.Stop_Explosion;
        public Index index;

        public GameObj target;
        //public bool free;
    }
}
