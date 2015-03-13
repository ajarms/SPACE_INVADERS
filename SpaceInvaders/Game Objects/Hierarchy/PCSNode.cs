using System;

namespace SpaceInvaders
{
    abstract class PCSNode
    {
        //------------------
        public PCSNode()
        {
            this.parent = null;
            this.child = null;
            this.sibling = null;
        }

        public PCSTree getTree()
        {
            PCSNode curr = this.parent;

            while (curr.parent != null)
            {
                curr = curr.parent;
            }

            return (curr as PCSRoot).tree;
        }

        //------------------
        abstract public Enum getName();
        abstract public Enum getIndex();
        //------------------
        public PCSNode parent;
        public PCSNode child;
        public PCSNode sibling;
    }
}
