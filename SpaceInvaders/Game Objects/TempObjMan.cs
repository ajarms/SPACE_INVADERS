using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class TempObjMan : Man
    {
        // private, only create calls constructor
        private TempObjMan(int numNodes, int nodeGrowth)
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
                instance = new TempObjMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static TempObjMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static void add(GameObj target)
        {
            TempObjMan tmp = TempObjMan.getInstance();

            TempObjNode toAdd = tmp.baseAdd() as TempObjNode;
            toAdd.set(target);
        }

        // search the active list; null on fail-to-find
        public static GameObj find(Enum _name, Index _index = Index._0)
        {
            TempObjMan tmp = TempObjMan.getInstance();

            TempObjNode pNode = tmp.baseFind(_name, _index) as TempObjNode;

            if (pNode == null)
            { return null; }

            return pNode.pGameObj;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            TempObjMan tmp = TempObjMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            TempObjMan tmp = TempObjMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            TempObjNode proj = new TempObjNode();
            return proj;
        }

        public static void printStats()
        {
            TempObjMan tmp = TempObjMan.getInstance();

            Debug.WriteLine("PROJECTILE MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static TempObjMan instance;
    }

}

