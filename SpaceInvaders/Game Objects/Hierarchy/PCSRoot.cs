using System;

namespace SpaceInvaders
{
    class PCSRoot : PCSNode
    {
        public PCSRoot(PCSTree.Name _name)
        {
            this.name = _name;
            this.index = Index._0;
        }

        public override Enum getName()
        {
            return this.name;
        }

        public override Enum getIndex()
        {
            return this.index;
        }

        public PCSTree tree;
        private PCSTree.Name name;
        private Index index;
    }
}
