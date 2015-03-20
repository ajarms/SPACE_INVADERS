using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    
        abstract class SubMan: MLink
        {

            protected SubMan(int startNode, int nodeGrowth)
                :base()
            {
                this.active = null;
                this.reserved = null;

                this.stats.numActive = 0;
                this.stats.numReserved = 0;
                this.stats.maxActive = 0;
                this.stats.nodeGrowth = nodeGrowth;
                this.stats.startNodes = startNode;

                this.fillReserve(startNode);
            }

            private SubMan()
            { }



            protected SubLink baseAdd()
            {
                // get from head of reserve list
                // check for reserve nodes
                if (reserved == null)
                {
                    this.fillReserve(this.stats.nodeGrowth);
                    this.stats.numReserved += this.stats.nodeGrowth;
                }
                // confirm reserve nodes
                Debug.Assert(reserved != null);
                // grab head node
                SubLink toAdd = reserved;
                // fix links
                reserved = toAdd.next;
                if (toAdd.next != null)
                {
                    toAdd.next.prev = toAdd.prev;
                }

                // add to head of active list
                if (active == null)
                {
                    active = toAdd;
                    toAdd.prev = null;
                    toAdd.next = null;
                }
                else
                {
                    toAdd.prev = null;
                    toAdd.next = active;
                    active.prev = toAdd;
                    active = toAdd;
                }

                // update stats
                this.stats.numReserved--;
                this.stats.numActive++;
                if (this.stats.numActive > this.stats.maxActive)
                {
                    this.stats.maxActive = this.stats.numActive;
                }

                // return new active head
                return toAdd;
            }

            protected SubLink baseFind(Enum _name, Index _index)
            {
                SubLink tmp = this.active;

                while (tmp != null)
                {
                    if (tmp.getName().Equals(_name) && tmp.getIndex().Equals(_index))
                    {
                        break;
                    }

                    tmp = tmp.next;
                }

                return tmp;
            }

            protected void baseRemove(SubLink tmp)
            {
                if (tmp != null)
                {
                    // remove from active list
                    if (tmp.prev != null)
                    {
                        tmp.prev.next = tmp.next;
                    }
                    else
                    {
                        active = tmp.next;
                    }
                    if (tmp.next != null)
                    {
                        tmp.next.prev = tmp.prev;
                    }


                    // add to reserve list head
                    if (reserved == null)
                    {
                        reserved = tmp;
                        tmp.next = null;
                        tmp.prev = null;
                    }
                    else
                    {
                        tmp.next = reserved;
                        reserved.prev = tmp;
                        reserved = tmp;
                        tmp.prev = null;
                    }


                    // update stats
                    this.stats.numActive--;
                    this.stats.numReserved++;
                }
            }

            protected void baseRemove(Enum _name, Index _index)
            {
                // find texture & remove
                SubLink tmp = this.baseFind(_name, _index);

                baseRemove(tmp);
            }

            protected void baseDestroy()
            {
                // destroy everything on the reserved list
                // inheriting classes should be able to call this to delete all of the reserve & active
                // regardless of the content of the nodes

                this.active = null;

                this.reserved = null;
            }

            abstract protected object getNew();

            private void fillReserve(int numNodes)
            {
                for (int i = 0; i < numNodes; i++)
                {
                    SubLink obj = getNew() as SubLink;
                    // add obj to reserve list head
                    if (reserved == null)
                    {
                        reserved = obj;
                        obj.next = null;
                        obj.prev = null;
                    }
                    else
                    {
                        obj.next = reserved;
                        reserved.prev = obj;
                        reserved = obj;
                        obj.prev = null;
                    }
                }

                // update stats
                this.stats.numReserved += numNodes;
            }

            //--------------
            protected struct Stats
            {
                public int numActive;
                public int numReserved;
                public int nodeGrowth;
                public int startNodes;
                public int maxActive;
            }

            protected SubLink active;
            protected SubLink reserved;
            protected Stats stats;
        }
   
}
