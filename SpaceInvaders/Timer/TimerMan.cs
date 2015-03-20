using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimerMan: PriorityQueue
    {
        // private, only create calls constructor
        private TimerMan(int numNodes, int nodeGrowth)
            : base(numNodes, nodeGrowth)
        {
            this.currTime = 0.0f;
        }

        // creates singleton, calls constructor, fills reserve list
        public static void create(int numNodes=3, int nodeGrowth=2)
        {
            Debug.Assert(numNodes > 0 && nodeGrowth > 0);
            Debug.Assert(instance == null);

            // check for instance
            if (instance == null)
            {
                // constructor will fill reserve
                instance = new TimerMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static TimerMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active in time-sorted order
        public static void add(Timer.Name _name, Event _event, float deltaTime)
        {
            TimerMan tmp = TimerMan.getInstance();

            Timer toAdd = tmp.getReserved() as Timer;

            toAdd.set(_name, _event, deltaTime);

            tmp.enqueue(toAdd);

            tmp.stats.numActive++;
            if (tmp.stats.numActive > tmp.stats.maxActive)
            {
                tmp.stats.maxActive = tmp.stats.numActive;
            }
        }

        // remove from queue
        public static void remove(Enum _name, Index _index = Index._0)
        {
            TimerMan tmp = TimerMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // update based on time
        public static void update(float totalTime)
        {
            TimerMan pTMan = TimerMan.getInstance();

            pTMan.currTime = totalTime;

            //walk the list
            Timer pTimer = pTMan.active as Timer;
            Timer pNext = null;

            //continue until a node with too high of a triggertime is hit
            //execute each node
            while((pTimer != null) && (pTimer.triggerTime <= pTMan.currTime))
            {
                pNext = pTimer.next as Timer;

                pTimer.execute();

                pTMan.baseRemove(pTimer);

                pTimer = pNext;
            }
        }

        // get the current time
        public static float getTime()
        {
            TimerMan tmp = TimerMan.getInstance();

            return tmp.currTime;
        }

        // pause all time events
        public static void wait(float waitTime)
        {
            TimerMan tmp = TimerMan.getInstance();

            Timer curr = tmp.active as Timer;

            while (curr != null)
            {
                curr.triggerTime += waitTime;

                curr = curr.next as Timer;
            }
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            TimerMan tmp = TimerMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            Timer tmr = new Timer();
            return tmr;
        }

        public static void printStats()
        {
            TimerMan tmp = TimerMan.getInstance();

            Debug.WriteLine("TIMER MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static TimerMan instance;
        protected float currTime;
    }
}
