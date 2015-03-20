using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    // timed movement event
    class MoveEvent: Event
    {
        public MoveEvent(Event.Name name, GameObj toMove, float deltaX, float deltaY)
            : base()
        {
            this.name = name;
            this.moveTarget = toMove;
            this.deltaX = deltaX;
            this.deltaY = deltaY;
        }

        ~MoveEvent()
        {
            this.moveTarget = null;
        }

        public override void execute(float deltaTime)
        {
            this.moveTarget.move(this.deltaX, this.deltaY);

            TimerMan.add(Timer.Name.AlienAnimationTimer, this, Constants.ALIEN_SPEED());
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
        public Name name;
        public Index index = Index._0;

        //movement component
        private GameObj moveTarget;
        private float deltaX;
        private float deltaY;
    }
}
