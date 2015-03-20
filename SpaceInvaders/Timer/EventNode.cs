using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class EventNode: MLink
    {
        public EventNode()
            : base()
        {
            this.pEvent = null;
        }

        public void set(Event target)
        {
            Debug.Assert(target != null);
            this.pEvent = target;
        }

        public void execute(float deltaTime)
        {
            Debug.Assert(pEvent != null);
            pEvent.execute(deltaTime);
        }

        public override Enum getName()
        {
            return pEvent.getName();
        }

        public override Enum getIndex()
        {
            return pEvent.getIndex();
        }

        //----------------//
        public Event pEvent;
    }
}
