using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Factory
    {
        protected Factory()
        {
            this.currBatch = null;
            this.colBatch = null;
            this.tree = null;
            this.parent = null;
        }

        // set object tree to add new objects to
        protected PCSTree setPCSTree()
        {
            if (this.tree == null)
            {
                PCSTree newTree = new PCSTree();

                this.tree = newTree;
                this.parent = newTree.getRoot();
            }
            else
            {
                this.parent = this.tree.getRoot();
            }
            return this.tree;
        }

        // sets batch to add new game objects to
        protected SpriteBatch setBatch(SpriteBatch.Name batchName)
        {
            this.currBatch = SBatchMan.find(batchName);
            return currBatch;
        }

        // set batch to add new collision objects to
        protected SpriteBatch setColBatch(SpriteBatch.Name colGroup)
        {
            this.colBatch = SBatchMan.find(colGroup);
            return colBatch;
        }

        // set parent to attach new objects to
        protected void setParent(PCSNode _node)
        {
            this.parent = _node;
        }


        protected SpriteBatch currBatch;
        protected SpriteBatch colBatch;
        protected PCSTree tree;
        protected PCSNode parent;
    }
}
