using System;

namespace SpaceInvaders
{
    abstract class PriorityNode:MLink
    {
        public PriorityNode()
            : base()
        { }

        public abstract bool compare(PriorityNode compareTo);
    }
}
