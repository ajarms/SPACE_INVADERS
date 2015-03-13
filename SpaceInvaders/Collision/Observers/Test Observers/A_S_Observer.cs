using System;

namespace SpaceInvaders
{
    class A_S_Observer : Observer
    {
        public A_S_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("Alien hit Shield");
        }
    }
}
