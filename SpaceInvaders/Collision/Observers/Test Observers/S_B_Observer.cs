using System;

namespace SpaceInvaders
{
    class S_B_Observer: Observer
    {
        public S_B_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Bomb Hit Shield");
        }
    }
}
