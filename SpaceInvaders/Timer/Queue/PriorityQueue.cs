using System;

namespace SpaceInvaders
{
    abstract class PriorityQueue:Man
    {
        protected PriorityQueue(int numNodes, int nodeGrowth)
            : base(numNodes, nodeGrowth)
        {
        }


        public void enqueue(PriorityNode toAdd)
        {
            // new item & cursor
            PriorityNode newNode = toAdd;
            PriorityNode curr = this.active as PriorityNode;
            
            // empty list, add at head
            if (curr == null)
            {
                this.active = newNode;
                newNode.next = null;
                newNode.prev = null;
            }
            // smaller than existing head, add at head
            else if (newNode.compare(curr))
            {
                this.active = newNode;
                newNode.next = curr;
                newNode.prev = null;
                curr.prev = newNode;
            }
            // otherwise, keep walking
            else
            {
                while (curr.next != null)
                {
                    // if a larger node is found, stop walking
                    if (newNode.compare(curr.next as PriorityNode))
                    {
                        break;
                    }

                    curr = curr.next as PriorityNode;
                }

                // a larger node was found
                if (curr.next != null)
                {
                    newNode.next = curr.next;
                    newNode.prev = curr;
                    curr.next = newNode;
                    newNode.next.prev = newNode;
                }
                // no larger node, end of list
                else
                {
                    curr.next = newNode;
                    newNode.prev = curr;
                    newNode.next = null;
                }
            }
        }
    }
}
