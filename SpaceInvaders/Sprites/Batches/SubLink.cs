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

        virtual public Enum getName()
        {
            return null;
        }

        public SubLink prev;
        public SubLink next;

    }
}
