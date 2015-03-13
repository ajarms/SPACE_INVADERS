using System;

namespace SpaceInvaders
{
    class P_W_Observer: Observer
    {
        public P_W_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Player hit Wall");
        }
    }
}
