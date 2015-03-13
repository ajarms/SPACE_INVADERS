using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class NSprite:GSprite
    {
        private NSprite()
        {
        }

        public NSprite(BSprite.Name spriteName, Index _index = Index._0)
            :base( spriteName, _index)
        {
            this.img = new NImage();
        }

        override public void update()
        {
        }

        override public void draw()
        {
        }

        public override float getHeight()
        {
            return 0.0f;
        }

        public override float getWidth()
        {
            return 0.0f;
        }
    }
}
