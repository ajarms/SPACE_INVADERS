using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatch: SubMan
    {
        public enum Name
        {
            Aliens,
            Projectiles,
            Background,
            Collision,
            Midground,
            NOT_INITIALIZED
        }


        public SpriteBatch(int numNodes, int nodeGrowth)
            : base(numNodes, nodeGrowth)
        {
            this.name = Name.NOT_INITIALIZED;
        }

        // grabs from reserve, sets values, adds to active
        public void add(BSprite _sprite)
        {
            // grabs blank batchnode and points it to the named sprite
            BatchNode toAdd = this.baseAdd() as BatchNode;
            toAdd.set(_sprite);
            _sprite.batch = this;
        }

        // search the active list; null on fail-to-find
        public BatchNode find(Enum _name)
        {
            return this.baseFind(_name) as BatchNode;
        }

        // remove from active list, put on reserve
        public void remove(Enum _name)
        {
            this.baseRemove(_name);
        }

        public void remove(BSprite outSprite)
        {
            //this.baseRemove(sprite);
            BatchNode curr = this.active as BatchNode;
            BatchNode toRemove = null;

            while (curr != null)
            {
                if (curr.sprite == outSprite)
                {
                    toRemove = curr;
                }
                curr = curr.next as BatchNode;
            }

            Debug.Assert(toRemove != null);
            this.baseRemove(toRemove);
        }

        // releases everything on the active and reserve lists for GC
        public void destroy()
        {
            this.baseDestroy();
        }

        public void set(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        override protected object getNew()
        {
            BatchNode tmp = new BatchNode();
            return tmp;
        }

        // steps through each active node and draws
        public void draw()
        {
            BatchNode curr = this.active as BatchNode;

            // start steppin'
            while (curr != null)
            {
                curr.draw();

                curr = curr.next as BatchNode;
            }
        }


        // contract with base class
        public override Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //---------------------
        public Name name;
        public Index index = Index._0;
        public bool enabled = true;
    }
}
