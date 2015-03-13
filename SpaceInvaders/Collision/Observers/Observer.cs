using System;

namespace SpaceInvaders
{
    abstract class Observer
    {
        public Observer()
        {
            this.next = null;
            this.prev = null;
            this.target = null;
        }

        abstract public void notify();

        //-------------------
        public Observer next;
        public Observer prev;
        public Subject target;
    }
}
