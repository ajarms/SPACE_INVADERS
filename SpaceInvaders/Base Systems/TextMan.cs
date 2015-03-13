using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextMan : Man
    {
        // private, only create calls constructor
        private TextMan(int numNodes, int nodeGrowth)
            : base(numNodes, nodeGrowth)
        {
            
        }

        // creates singleton, calls constructor, fills reserve list
        public static void create(int numNodes=3, int nodeGrowth=2)
        {
            Debug.Assert(numNodes > 0 && nodeGrowth > 0);
            Debug.Assert(instance == null);

            if (instance == null)
            {
                instance = new TextMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static TextMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static void add(Texture.Name inName, string inFile)
        {
            TextMan tmp = TextMan.getInstance();

            Texture toAdd = tmp.baseAdd() as Texture;
            toAdd.set(inName, inFile);
        }

        // search the active list; null on fail-to-find
        public static Texture find (Enum _name, Index _index = Index._0)
        {
            TextMan tmp = TextMan.getInstance();

            return tmp.baseFind(_name, _index) as Texture;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            TextMan tmp = TextMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            TextMan tmp = TextMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            Texture txt = new Texture();
            return txt;
        }

        public static void printStats()
        {
            TextMan tmp = TextMan.getInstance();

            Debug.WriteLine("TEXTURE MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable textman
        private static TextMan instance;

    }
}
