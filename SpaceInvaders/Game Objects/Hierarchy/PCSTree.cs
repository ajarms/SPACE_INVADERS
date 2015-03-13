using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PCSTree
    {
        public PCSTree()
        {
            this.root = null;
            this.stats.maxNodeCount = 0;
            this.stats.numNodes = 0;

            PCSRoot root = new PCSRoot(PCSTree.Name.Root);
            root.tree = this;
            this.insert(root, null);
        }

        public PCSNode getRoot()
        {
            return this.root;
        }

        public void insert(PCSNode _node, PCSNode _parent)
        {
            // verify contents
            Debug.Assert(_node != null);

            // if no parent, add at root
            if (_parent == null)
            {
                this.root = _node;
                _node.child = null;
                _node.parent = null;
                _node.sibling = null;
            }
            else
            {
                // if parent has no children, add as child
                if (_parent.child == null)
                {
                    _parent.child = _node;
                    _node.parent = _parent;
                    _node.child = null;
                    _node.sibling = null;
                }
                // otherwise, add as sibling
                else
                {
                    PCSNode first = _parent.child;
                    _node.parent = _parent;
                    _node.child = null;
                    _node.sibling = first;
                    _parent.child = _node;
                }
            }
            // update stats
            this.stats.numNodes++;
            if (this.stats.numNodes > this.stats.maxNodeCount)
            {
                this.stats.maxNodeCount = this.stats.numNodes;
            }
        }

        public void remove(PCSNode _node)
        {
            
            // verify contents
            Debug.Assert(_node != null);

            PCSNode inParent = _node.parent;

            // no children, remove and reset siblings
            if (_node.child == null)
            {
                if (_node.sibling == null)
                {
                    // no sibling no parent, its the root
                    if (_node.parent == null)
                    {
                        this.root = null;
                    }
                    // no sibling
                    else
                    {
                        PCSNode pTmp;
                        // goto eldest child
                        pTmp = inParent.child;
                        Debug.Assert(pTmp != null);

                        if (pTmp.sibling == null)
                        {   // delete inNode so it's parent is 0
                            // in child has no siblings
                            inParent.child = null;
                        }
                        else
                        {   // now iterate until child
                            while (pTmp.sibling != _node)
                            {
                                pTmp = pTmp.sibling;
                            }
                            // this point we found the sibling
                            PCSNode pPrev = pTmp;
                            pPrev.sibling = null;
                        }
                    }
                }
                // no children
                else
                {
                    // go to eldest child
                    PCSNode pTmp = inParent.child;
                    Debug.Assert(pTmp != null);

                    if (pTmp == _node)
                    {   // we are deleting a eldest child with siblings
                        inParent.child = pTmp.sibling;
                    }
                    else
                    {   // now iterate until child
                        while (pTmp.sibling != _node)
                        {
                            pTmp = pTmp.sibling;
                        }
                        // this point we found the sibling
                        PCSNode pPrev = pTmp;
                        pPrev.sibling = _node.sibling;
                    }
                }

                // update data
                _node.parent = null;
                _node.child = null;
                _node.sibling = null;
                this.stats.numNodes--;
            }
            // if node has children, recursively remove children
            else
            {
                this.remove(_node.child);
                this.remove(_node);
            }
        }

        //------------------------
        protected struct Stats
        {
            public int numNodes;
            public int maxNodeCount;
        }

        private PCSNode root;
        protected Stats stats;
        //------------------------
        public enum Name
        {
            Root,
            NOT_INITIALIZED
        }

    }
}
