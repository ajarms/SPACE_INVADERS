using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Subject
    {
        public Subject()
        {
            this.subA = null;
            this.subB = null;
            this.listHead = null;
        }

        ~Subject()
        {
            this.subA = null;
            this.subB = null;

            Observer curr = listHead;
            while (curr != null)
            {
                curr = listHead;
                listHead = curr.next;
                curr = null;
            }
            listHead = null;
        }

        // sets current observer subjects
        public void set(GameObj objA, GameObj objB)
        {
            Debug.Assert(objA != null);
            subA = objA;    

            Debug.Assert(objB != null);
            subB = objB;
        }

        // adds an observer to the list
        public void attach(Observer obs)
        {
            Debug.Assert(obs != null);
            if (listHead == null)
            {
                this.listHead = obs;
                obs.prev = null;
                obs.next = null;
            }
            else
            {
                listHead.prev = obs;
                obs.next = listHead;
                obs.prev = null;
                listHead = obs;
            }
        }

        // notifies each attached observer
        public void notify()
        {
            Observer curr = listHead;

            while (curr != null)
            {
                curr.notify();

                curr = curr.next;
            }
        }

        //------------------
        public GameObj subA;
        public GameObj subB;
        public Observer listHead;
    }
}
