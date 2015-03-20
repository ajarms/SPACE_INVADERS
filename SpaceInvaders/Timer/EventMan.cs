using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class EventMan: Man
    {
        // private, only create calls constructor
        private EventMan(int numNodes, int nodeGrowth)
            : base(numNodes, nodeGrowth)
        {
            
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
                instance = new EventMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static EventMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static Event add(Event target)
        {
            EventMan tmp = EventMan.getInstance();

            EventNode toAdd = tmp.baseAdd() as EventNode;

            toAdd.set(target);

            return toAdd.pEvent;
        }

        // search the active list; null on fail-to-find
        public static Event find(Enum _name, Index _index = Index._0)
        {
            EventMan tmp = EventMan.getInstance();

            EventNode eve = tmp.baseFind(_name, _index) as EventNode;

            if (eve == null) { return null; }
            
            return eve.pEvent;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            EventMan tmp = EventMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            EventMan tmp = EventMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            EventNode e = new EventNode();
            return e;
        }

        public static void printStats()
        {
            EventMan tmp = EventMan.getInstance();

            Debug.WriteLine("EVENT MANAGER");

            tmp.basePrintStats();
        }

        //--------------------------
        private static EventMan instance;
    }
}
