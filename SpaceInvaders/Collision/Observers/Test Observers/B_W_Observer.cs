using System;

namespace SpaceInvaders
{
    class B_W_Observer: Observer
    {
        public B_W_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Bomb hit Wall");
        }
    }
}
