using System;

namespace SpaceInvaders
{
    abstract class MLink
    {

        public MLink()
        {
            this.next = null;
            this.prev = null;
        }

        ~MLink()
        {
        }

        public MLink(MLink p, MLink n)
        {
            this.next = n;
            this.prev = p;
        }

        abstract public Enum getName();

        abstract public Enum getIndex();

        public MLink prev;
        public MLink next;

    }
}
