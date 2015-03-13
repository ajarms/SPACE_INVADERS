using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class ImgMan : Man
    {
        // private, only create calls constructor
        private ImgMan(int numNodes, int nodeGrowth)
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
                instance = new ImgMan(numNodes, nodeGrowth);
            }
        }

        // instance-grabber, used by static methods.
        protected static ImgMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static void add(Image.Name inName, Texture.Name inText, int x, int y, int width, int height)
        {
            ImgMan tmp = ImgMan.getInstance();

            Image toAdd = tmp.baseAdd() as Image;
            toAdd.set(inName, inText, x, y, width, height);
        }

        // search the active list; null on fail-to-find
        public static Image find(Enum _name, Index _index = Index._0)
        {
            ImgMan tmp = ImgMan.getInstance();

            return tmp.baseFind(_name, _index) as Image;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            ImgMan tmp = ImgMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            ImgMan tmp = ImgMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            Image img = new Image();
            return img;
        }

        public static void printStats()
        {
            ImgMan tmp = ImgMan.getInstance();

            Debug.WriteLine("IMAGE MANAGER");

            tmp.basePrintStats();
        }

        //-----------------------------------------------------------
        // single untouchable Manager
        private static ImgMan instance;
    }

}
