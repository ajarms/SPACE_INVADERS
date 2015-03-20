using System;

namespace SpaceInvaders
{
    abstract class State
    {
        protected State(){ }

        public abstract void handle(GameObj context);
    }
}
