using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SBatchMan: Man
    {
        // private, only create calls constructor
        private SBatchMan(int numNodes, int nodeGrowth)
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
                instance = new SBatchMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static SBatchMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static SpriteBatch add(SpriteBatch.Name inName)
        {
            SBatchMan tmp = SBatchMan.getInstance();

            SpriteBatch toAdd = tmp.baseAdd() as SpriteBatch;
            toAdd.set(inName);
            return toAdd;
        }

        // search the active list; null on fail-to-find
        public static SpriteBatch find(Enum _name, Index _index = Index._0)
        {
            SBatchMan tmp = SBatchMan.getInstance();

            return tmp.baseFind(_name, _index) as SpriteBatch;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            SBatchMan tmp = SBatchMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            SBatchMan tmp = SBatchMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            SpriteBatch gSpr = new SpriteBatch(3, 2);
            return gSpr;
        }

        // steps through each active batch and draws
        public static void draw()
        {
            SBatchMan tmp = SBatchMan.getInstance();

            SpriteBatch curr = tmp.active as SpriteBatch;

            // start steppin'
            while (curr != null)
            {
                // only draw enabled batches
                if (curr.enabled)
                {
                    curr.draw();
                }
                curr = curr.next as SpriteBatch;
            }
        }

        // selectively disable a batch from drawing
        public static void drawOff(SpriteBatch.Name _name)
        {
            SBatchMan.find(_name).enabled = false;
        }

        // selectively re-enable a batch to draw; batches are enabled by default
        public static void drawOn(SpriteBatch.Name _name)
        {
            SBatchMan.find(_name).enabled = true;
        }

        public static void printStats()
        {
            SBatchMan tmp = SBatchMan.getInstance();

            Debug.WriteLine("SPRITE BATCH MANAGER");

            tmp.basePrintStats();
        }


        //-----------------------------------------------------------
        // single untouchable manager
        private static SBatchMan instance;

    }
}
