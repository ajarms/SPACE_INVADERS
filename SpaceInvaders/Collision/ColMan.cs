using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColMan: Man
    {
        // private, only create calls constructor
        private ColMan(int numNodes, int nodeGrowth)
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
                instance = new ColMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static ColMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static ColPair add(ColPair.Name _name, GameObj rootA, GameObj rootB)
        {
            ColMan tmp = ColMan.getInstance();

            ColPair toAdd = tmp.baseAdd() as ColPair;
            toAdd.set(_name, rootA, rootB);

            return toAdd;
        }

        // search the active list; null on fail-to-find
        public static ColPair find(Enum _name, Index _index = Index._0)
        {
            ColMan tmp = ColMan.getInstance();

            return tmp.baseFind(_name, _index) as ColPair;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            ColMan tmp = ColMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            ColMan tmp = ColMan.getInstance();

            tmp.baseDestroy();
        }

        // returns actively colliding pair
        public static ColPair getActivePair()
        {
            return ColMan.getInstance().activePair;
        }

        // sets actively colliding collisionPair for public access
        private void setActive(ColPair toSet)
        {
            ColMan.getInstance().activePair = toSet;
        }

        // checks all collisions
        public static void update()
        {
            // step through each collision pair
            ColMan tmp = ColMan.getInstance();
            ColPair curr = tmp.active as ColPair;

            while (curr != null)
            {
                tmp.setActive(curr);
                ColPair.collide(curr.treeA, curr.treeB);
                curr = curr.next as ColPair;
            }
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            ColPair pair = new ColPair();
            return pair;
        }

        public static void printStats()
        {
            ColMan tmp = ColMan.getInstance();

            Debug.WriteLine("COLLISION MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static ColMan instance;
        private ColPair activePair = null;
    }
}
