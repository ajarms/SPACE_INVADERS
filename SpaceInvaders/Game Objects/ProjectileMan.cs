using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class ProjectileMan : Man
    {
        // private, only create calls constructor
        private ProjectileMan(int numNodes, int nodeGrowth)
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
                instance = new ProjectileMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static ProjectileMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static void add(GameObj target)
        {
            ProjectileMan tmp = ProjectileMan.getInstance();

            ProjectileNode toAdd = tmp.baseAdd() as ProjectileNode;
            toAdd.set(target);
        }

        // search the active list; null on fail-to-find
        public static GameObj find(Enum _name, Index _index = Index._0)
        {
            ProjectileMan tmp = ProjectileMan.getInstance();

            ProjectileNode pNode = tmp.baseFind(_name, _index) as ProjectileNode;

            Debug.Assert(pNode != null);

            return pNode.pGameObj;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            ProjectileMan tmp = ProjectileMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            ProjectileMan tmp = ProjectileMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            ProjectileNode proj = new ProjectileNode();
            return proj;
        }

        public static void printStats()
        {
            ProjectileMan tmp = ProjectileMan.getInstance();

            Debug.WriteLine("PROJECTILE MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static ProjectileMan instance;
    }

}

