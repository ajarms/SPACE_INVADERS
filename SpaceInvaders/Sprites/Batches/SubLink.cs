using System;

namespace SpaceInvaders
{
    abstract class SubLink
    {

        public SubLink()
        {
            this.next = null;
            this.prev = null;
        }

        ~SubLink()
        {
        }

        public SubLink(SubLink p, SubLink n)
        {
            this.next = n;
            this.prev = p;
        }

        abstract public Enum getName();

        abstract public Enum getIndex();

        public SubLink prev;
        public SubLink next;

    }
}
