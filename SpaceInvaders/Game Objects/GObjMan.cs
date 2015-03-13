using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GObjMan: Man
    {
        // private, only create calls constructor
        private GObjMan(int numNodes, int nodeGrowth)
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
                instance = new GObjMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static GObjMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }
        
        // grabs node from reserve, attaches a Game Object, adds to active
        public static GameObj add(GameObj gObj)
        {
            GObjMan tmp = GObjMan.getInstance();

            GObjectNode toAdd = tmp.baseAdd() as GObjectNode;
            toAdd.set(gObj);

            return toAdd.pGameObj;
        }

        // search the active list; null on fail-to-find
        public static GameObj find(GameObj.Type _type, Enum _name, Index _index = Index._0)
        {
            GObjMan tmp = GObjMan.getInstance();

            GObjectNode pNode = tmp.active as GObjectNode;

            while (pNode != null)
            {
                if (pNode.pGameObj.type.Equals(_type))
                {
                    GameObj pObj = pNode.pGameObj;

                    if (pObj != null)
                    {
                        return tmp.treeSearch(pObj, _name, _index);
                    }
                }
                pNode = pNode.next as GObjectNode;
            }

            return null;
        }

        private GameObj treeSearch(GameObj pObj, Enum _name, Index _index)
        {
            if (pObj.name.Equals(_name) && pObj.index.Equals(_index))
            {
                return pObj;
            }

            GObjMan tmp = GObjMan.getInstance();

            if (pObj.sibling != null)
            {
                tmp.treeSearch(pObj.sibling as GameObj, _name, _index);
            }

            if (pObj.child != null)
            {
                tmp.treeSearch(pObj.child as GameObj, _name, _index);
            }

            return null;
        }

        private PCSTree findTree(GameObj.Type _type)
        {
            GObjMan tmp = GObjMan.getInstance();

            GObjectNode pObj = tmp.active as GObjectNode;

            while (pObj != null)
            {
                if (pObj.pGameObj.type.Equals(_type))
                {
                    return pObj.pGameObj.getTree();
                }
                pObj = pObj.next as GObjectNode;
            }

            return null;
        }

        // remove from active list, put on reserve
        public static void remove(GameObj.Type _type, Enum _name, Index _index = Index._0)
        {
            GObjMan tmp = GObjMan.getInstance();

            GameObj pObj = GObjMan.find(_type, _name, _index);

            tmp.findTree(_type).remove(pObj);
        }

        public static void remove(GameObj pObj)
        {
            GObjMan tmp = GObjMan.getInstance();

            tmp.findTree(pObj.type).remove(pObj);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            GObjMan tmp = GObjMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            GObjectNode img = new GObjectNode();
            return img;
        }

        // updates all of the game objects
        public static void update()
        {
            GObjMan tmp = GObjMan.getInstance();

            GObjectNode curr = tmp.active as GObjectNode;

            while (curr != null)
            {
                curr.pGameObj.update();

                curr = curr.next as GObjectNode;
            }
        }

        // accessor for current alien count
        public static float alienCount()
        {
            GObjMan tmp = GObjMan.getInstance();

            return tmp.numAliens;
        }

        // resets alien count when aliens are initialized
        public static void resetAlienCount()
        {
            GObjMan tmp = GObjMan.getInstance();

            tmp.numAliens = 55.0f;
        }

        // updates count when an alien is killed
        public static void updateAlienCount()
        {
            GObjMan tmp = GObjMan.getInstance();

            --tmp.numAliens;
        }

        public static void printStats()
        {
            GObjMan tmp = GObjMan.getInstance();

            Debug.WriteLine("GAME OBJECT MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static GObjMan instance;
        private float numAliens; // count needed to calculate alien speed
    }
}
