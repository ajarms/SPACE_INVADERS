using System;

namespace SpaceInvaders
{
    class U_W_Observer: Observer
    {
        public U_W_Observer()
            : base()
        { }

        public override void notify()
        {
            Console.WriteLine("UFO hit Wall");
        }
    }
}
