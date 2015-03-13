using System;

namespace SpaceInvaders
{
    abstract class Event: MLink
    {
        public enum Type
        {
            Animation,
            NOT_INITIALIZED
        }

        public Event()
            : base()
        {
        }

        abstract public void execute(float deltaTime);
    }
}