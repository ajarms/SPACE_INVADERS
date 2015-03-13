using System;

namespace SpaceInvaders
{
    class DestroyAlienObserver: Observer
    {
        public DestroyAlienObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;
            GameObj parent;

            if (pSub.subA is _Alien)
            {
                // trigger explosion
                ((pSub.subA.drawSprite as FSprite).target as GSprite).img = ImgMan.find(Image.Name.Alien_Explosion);
                pSub.subA.drawSprite.draw();

                // remove alien & remove columns if needed
                parent = pSub.subA.parent as GameObj;
                pSub.subA.removeMe();
                if (parent.child == null)
                {
                    parent.removeMe();
                }
            }
            else if (pSub.subB is _Alien)
            {
                parent = pSub.subB.parent as GameObj;
                pSub.subB.removeMe();
                if (parent.child == null)
                {
                    parent.removeMe();
                }
            }
            GObjMan.updateAlienCount();
        }
    }
}
