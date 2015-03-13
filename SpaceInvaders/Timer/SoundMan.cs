using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundMan : Man
    {
        // private, only create calls constructor
        private SoundMan(int numNodes, int nodeGrowth)
            : base(numNodes, nodeGrowth)
        {

        }

        // creates singleton, calls constructor, fills reserve list
        public static void create(int numNodes = 3, int nodeGrowth = 2)
        {
            Debug.Assert(numNodes > 0 && nodeGrowth > 0);
            Debug.Assert(instance == null);

            // check for instance
            if (instance == null)
            {
                // constructor will fill reserve
                instance = new SoundMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static SoundMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static SoundEvent add(SoundEvent.Name _name)
        {
            SoundMan tmp = SoundMan.getInstance();

            SoundEvent toAdd = tmp.baseAdd() as SoundEvent;

            toAdd.set(_name);

            return toAdd;
        }

        // search the active list; null on fail-to-find
        public static SoundEvent find(Enum _name, Index _index = Index._0)
        {
            SoundMan tmp = SoundMan.getInstance();

            return tmp.baseFind(_name, _index) as SoundEvent;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            SoundMan tmp = SoundMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            SoundMan tmp = SoundMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            SoundEvent e = new SoundEvent();
            return e;
        }

        public static void printStats()
        {
            SoundMan tmp = SoundMan.getInstance();

            Debug.WriteLine("SOUND MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static SoundMan instance;
    }
}
