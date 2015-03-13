using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteMan: Man
    {
        // private, only create calls constructor
        private SpriteMan(int numNodes, int nodeGrowth)
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
                instance = new SpriteMan(numNodes, nodeGrowth);
                instance.nullSprite = new NSprite(BSprite.Name.NullSprite);
            }
        }

        // instance-grabber, used by static methods.
        protected static SpriteMan getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        // grabs from reserve, sets values, adds to active
        public static void add(BSprite.Name inName, Image inImg, float x, float y, float sx = 1.0f, float sy = 1.0f, float angle = 0.0f)
        {
            SpriteMan tmp = SpriteMan.getInstance();

            GSprite toAdd = tmp.baseAdd() as GSprite;
            toAdd.set(inName, inImg, x, y, sx, sy, angle);
        }

        // search the active list; null on fail-to-find
        public static GSprite find(Enum _name, Index _index = Index._0)
        {
            SpriteMan tmp = SpriteMan.getInstance();

            if (_name.Equals(BSprite.Name.NullSprite))
            {
                return tmp.nullSprite;
            }

            return tmp.baseFind(_name, _index) as GSprite;
        }

        // remove from active list, put on reserve
        public static void remove(Enum _name, Index _index = Index._0)
        {
            SpriteMan tmp = SpriteMan.getInstance();

            tmp.baseRemove(_name, _index);
        }

        // releases everything on the active and reserve lists for GC
        public static void destroy()
        {
            SpriteMan tmp = SpriteMan.getInstance();

            tmp.baseDestroy();
        }

        // our factory, makes blanks for the reserve list
        protected override object getNew()
        {
            GSprite gSpr = new GSprite();
            return gSpr;
        }


        //-----------------------------------------------------------
        // single untouchable manager
        private static SpriteMan instance;
        private NSprite nullSprite;
    }
}
